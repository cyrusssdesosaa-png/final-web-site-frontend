using System.Net;
using System.Text;

namespace WallyWombatsPublic_MVC.Seo;

public static class SitemapXml
{
    /// <summary>
    /// Pages this app serves as 200 HTML without a database row.
    /// Active /locations/{slug} and /book/{slug} URLs are added from the Location table.
    /// /friends/{slug} URLs are added from the character catalog and active Friend rows.
    /// Published /blog/{slug} stories are added from the blog catalog when supplied.
    /// </summary>
    public static readonly string[] StaticPaths =
    {
        "/",
        "/book",
        "/pricing",
        "/privacy-policy",
        "/about-us",
        "/apps",
        "/calendar",
        "/contact-us",
        "/faq",
        "/blog"
    };

    /// <summary>Catalog profiles this site serves even when the Friend table is empty.</summary>
    public static readonly string[] DefaultFriendSlugs =
    {
        "ney-ney",
        "bunski",
        "wally",
        "don-don",
        "len-len"
    };

    public static string Build(string origin, IEnumerable<string>? locationSlugs, IEnumerable<string>? friendSlugs = null, IEnumerable<string>? blogSlugs = null)
    {
        var paths = new List<string>(StaticPaths);
        if (locationSlugs != null)
        {
            foreach (var slug in locationSlugs)
            {
                var clean = CleanSlug(slug);
                if (clean == null)
                    continue;
                Add(paths, "/locations/" + clean);
                Add(paths, "/book/" + clean);
            }
        }

        var friends = friendSlugs ?? DefaultFriendSlugs;
        foreach (var slug in friends)
        {
            var clean = CleanSlug(slug);
            if (clean == null)
                continue;
            Add(paths, "/friends/" + clean);
        }

        if (blogSlugs != null)
        {
            foreach (var slug in blogSlugs)
            {
                var clean = CleanSlug(slug);
                if (clean == null || clean is "page" or "category" or "archive" or "index")
                    continue;
                Add(paths, "/blog/" + clean);
            }
        }

        var xml = new StringBuilder();
        xml.AppendLine("""<?xml version="1.0" encoding="UTF-8"?>""");
        xml.AppendLine("""<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">""");
        foreach (var path in paths)
        {
            xml.Append("  <url><loc>");
            xml.Append(WebUtility.HtmlEncode(origin + path));
            xml.AppendLine("</loc></url>");
        }
        xml.AppendLine("</urlset>");
        return xml.ToString();
    }

    private static void Add(List<string> paths, string path)
    {
        if (!paths.Contains(path, StringComparer.Ordinal))
            paths.Add(path);
    }

    private static string? CleanSlug(string? slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return null;
        var clean = slug.Trim().Trim('/').ToLowerInvariant();
        if (clean.Length == 0 || clean.Contains('/') || clean.Contains(' ') || clean.Contains('?') || clean.Contains('#'))
            return null;
        return clean;
    }
}
