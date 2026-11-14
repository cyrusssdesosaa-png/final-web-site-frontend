using Microsoft.AspNetCore.Http;

namespace WallyWombatsPublic_MVC.Seo;

/// <summary>
/// Decides the single 301 target for a request. Local hosts (localhost, loopback)
/// keep their scheme and host so <c>dotnet run</c> on http://localhost still works.
/// Every other host is sent to <see cref="Origin"/>.
/// </summary>
public sealed class SeoRedirector
{
    private readonly Dictionary<string, LegacyTarget> _legacy;

    public SeoRedirector(string? officialOrigin)
        : this(officialOrigin, LegacyPathMap.Create())
    {
    }

    public SeoRedirector(string? officialOrigin, Dictionary<string, LegacyTarget> legacy)
    {
        Origin = SiteOptions.Normalize(officialOrigin);
        _legacy = legacy;
    }

    public string Origin { get; }

    public string? GetRedirectTarget(HttpRequest request)
    {
        return GetRedirectTarget(
            request.Method,
            request.Scheme,
            request.Host.Value,
            request.Host.Host,
            request.Path.Value ?? "/",
            request.QueryString.Value ?? "");
    }

    public string? GetRedirectTarget(string? method, string? scheme, string? hostWithPort, string? hostName, string? path, string? query)
    {
        if (string.IsNullOrEmpty(method) || (!HttpMethods.IsGet(method) && !HttpMethods.IsHead(method)))
            return null;

        var safePath = string.IsNullOrEmpty(path) ? "/" : path;
        if (!safePath.StartsWith('/'))
            safePath = "/" + safePath;

        var safeQuery = query ?? "";
        if (safeQuery.Length > 0 && safeQuery[0] != '?')
            safeQuery = "?" + safeQuery;

        var safeScheme = string.IsNullOrEmpty(scheme) ? "http" : scheme;
        var safeHost = string.IsNullOrEmpty(hostWithPort) ? (hostName ?? "") : hostWithPort;
        var local = IsLocalHost(hostName);
        var origin = local ? safeScheme + "://" + safeHost : Origin;

        string canonicalPath;
        var preserveQuery = true;
        if (IsStaticAsset(safePath))
        {
            canonicalPath = safePath;
        }
        else if (!TryCanonicalizePage(safePath, out canonicalPath, out preserveQuery))
        {
            return null;
        }

        var target = Combine(origin, canonicalPath, preserveQuery ? safeQuery : "");
        var current = safeScheme + "://" + safeHost + safePath + safeQuery;
        return string.Equals(current, target, StringComparison.Ordinal) ? null : target;
    }

    public string CanonicalHref(string? path)
    {
        var safePath = string.IsNullOrEmpty(path) ? "/" : path;
        if (!TryCanonicalizePage(safePath, out var canonical, out _))
            canonical = "/";

        var hash = canonical.IndexOf('#');
        if (hash >= 0)
            canonical = canonical[..hash];
        if (string.IsNullOrEmpty(canonical))
            canonical = "/";
        return Origin + canonical;
    }

    public static bool IsLocalHost(string? hostName)
    {
        if (string.IsNullOrEmpty(hostName))
            return false;
        if (hostName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            return true;
        if (hostName.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase))
            return true;
        if (hostName.Equals("::1", StringComparison.OrdinalIgnoreCase))
            return true;
        if (hostName.EndsWith(".localhost", StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    public static bool IsStaticAsset(string path)
    {
        if (string.IsNullOrEmpty(path) || path == "/")
            return false;

        var trimmed = path.Length > 1 ? path.TrimEnd('/') : path;
        var slash = trimmed.LastIndexOf('/');
        var file = slash >= 0 ? trimmed[(slash + 1)..] : trimmed;
        var dot = file.LastIndexOf('.');
        if (dot <= 0)
            return false;

        var ext = file[(dot + 1)..];
        if (ext.Equals("html", StringComparison.OrdinalIgnoreCase) || ext.Equals("htm", StringComparison.OrdinalIgnoreCase))
            return false;
        if (file.Equals("robots.txt", StringComparison.OrdinalIgnoreCase) || file.Equals("sitemap.xml", StringComparison.OrdinalIgnoreCase))
            return false;
        return true;
    }

    private bool TryCanonicalizePage(string path, out string canonicalPath, out bool preserveQuery)
    {
        preserveQuery = true;
        var trimmed = path.Length > 1 ? path.TrimEnd('/') : path;
        if (trimmed.Length == 0)
            trimmed = "/";

        var lower = trimmed.ToLowerInvariant();
        if (lower.Contains("://", StringComparison.Ordinal) || lower.StartsWith("//", StringComparison.Ordinal))
        {
            canonicalPath = "/";
            return false;
        }

        if (_legacy.TryGetValue(lower, out var target))
        {
            canonicalPath = target.Path;
            preserveQuery = target.PreserveQuery;
            return true;
        }

        if (lower.StartsWith("/blog/", StringComparison.Ordinal))
        {
            var slug = lower["/blog/".Length..];
            if (LegacyPathMap.OldBlogSlugs.Contains(slug))
            {
                canonicalPath = "/blog";
                preserveQuery = false;
                return true;
            }
        }

        canonicalPath = lower;
        return true;
    }

    private static string Combine(string origin, string canonicalPath, string query)
    {
        var hash = canonicalPath.IndexOf('#');
        if (hash >= 0)
        {
            var pathPart = canonicalPath[..hash];
            if (pathPart.Length == 0)
                pathPart = "/";
            return origin + pathPart + query + canonicalPath[hash..];
        }

        if (!canonicalPath.StartsWith('/'))
            canonicalPath = "/" + canonicalPath;
        return origin + canonicalPath + query;
    }
}

public readonly record struct LegacyTarget(string Path, bool PreserveQuery);

public static class LegacyPathMap
{
    public static readonly HashSet<string> OldBlogSlugs = new(StringComparer.Ordinal)
    {
        "building-blocks-importance-to-kids",
        "magic-of-laughter-on-kids",
        "managing-toddler-separation-anxiety-and-the-role-of-indoor-playground",
        "parents-guide-to-choosing-perfect-christmas-gift",
        "play-relax-connect-at-wally-wombats",
        "social-play-for-toddler-development",
        "tips-to-help-your-child-prepare-for-preschool",
        "unlocking-kids-potential-through-occupational-therapy"
    };

    public static Dictionary<string, LegacyTarget> Create()
    {
        var map = new Dictionary<string, LegacyTarget>(StringComparer.Ordinal);
        void Same(string from, string to) => map[from] = new LegacyTarget(to, PreserveQuery: true);
        void Gone(string from, string to) => map[from] = new LegacyTarget(to, PreserveQuery: false);

        Same("/index", "/");
        Same("/index.html", "/");
        Same("/home", "/");
        Same("/home/index", "/");

        Same("/home/book", "/book");
        Same("/home/find", "/book");
        Same("/home/pricing", "/pricing");
        Same("/home/blog", "/blog");
        Same("/home/calendar", "/calendar");
        Same("/home/contactus", "/contact-us");
        Same("/home/aboutus", "/about-us");
        Same("/home/apps", "/apps");
        Same("/home/faqs", "/faq");
        Same("/home/privacy", "/privacy-policy");
        Same("/home/welcome", "/welcome");
        Same("/home/menuhenderson", "/menu-henderson");
        Same("/home/menurainbow", "/menu-rainbow");

        Same("/about", "/about-us");
        Same("/contact", "/contact-us");
        Same("/faqs", "/faq");
        Same("/privacy", "/privacy-policy");
        Same("/privacy_policy", "/privacy-policy");
        Same("/privacypolicy", "/privacy-policy");

        Gone("/post", "/blog");
        Gone("/home/blogpost", "/blog");
        Gone("/home/moreblogpost", "/blog");
        Gone("/posts", "/blog");

        Gone("/birthday", "/book");
        Gone("/birthday-parties", "/book");
        Gone("/birthday-parties-henderson", "/book/henderson");
        Gone("/birthday_parties_north_rainbow", "/book/las-vegas");

        Gone("/playground", "/#playground");
        Gone("/the-playground", "/#playground");
        Gone("/playground-prices-henderson", "/book/henderson");
        Gone("/playground-prices-north-rainbow", "/book/las-vegas");
        Gone("/playground_prices_north_rainbow", "/book/las-vegas");
        Gone("/prices", "/pricing");
        Gone("/book/north-rainbow", "/book/las-vegas");

        Gone("/friends", "/#crew");
        Gone("/locations", "/#locations");
        // Live stubs answer GET with a script that jumps to the contact section.
        Gone("/subscribe", "/#contact");
        Gone("/home/sendemail_index", "/#contact");
        return map;
    }
}
