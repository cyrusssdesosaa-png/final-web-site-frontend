using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using WallyWombatsPublic_MVC.Seo;

namespace WallyWombatsPublic_MVC.Models;

public sealed class BlogCard
{
    public string Slug { get; init; } = "";

    public string Title { get; init; } = "";

    public string Excerpt { get; init; } = "";

    public string? ImageUrl { get; init; }

    public DateTimeOffset Published { get; init; }

    public string? Category { get; init; }

    public string? CategorySlug { get; init; }

    public string Source { get; init; } = "";

    public string? ExternalId { get; init; }

    public string Path => "/blog/" + Slug;
}

public sealed class BlogFacet
{
    public string Label { get; init; } = "";

    public string Path { get; init; } = "/blog";

    public int Count { get; init; }

    public bool Selected { get; init; }
}

public sealed class BlogPage
{
    public IReadOnlyList<BlogCard> Posts { get; init; } = Array.Empty<BlogCard>();

    public int PageNumber { get; init; } = 1;

    public int Total { get; init; }

    public int TotalPages { get; init; } = 1;

    public bool Known { get; init; } = true;

    public string? CategorySlug { get; init; }

    public string? CategoryName { get; init; }

    public int? Year { get; init; }

    public int? Month { get; init; }

    public string Path { get; init; } = "/blog";

    public string? PrevPath { get; init; }

    public string? NextPath { get; init; }

    public IReadOnlyList<BlogFacet> Categories { get; init; } = Array.Empty<BlogFacet>();

    public IReadOnlyList<BlogFacet> Archives { get; init; } = Array.Empty<BlogFacet>();

    public string Heading { get; init; } = "Wally's blog";
}

public sealed class BlogArticle
{
    public BlogCard Post { get; init; } = new();

    public string Html { get; init; } = "";

    public bool BodyUnavailable { get; init; }

    public BlogCard? Newer { get; init; }

    public BlogCard? Older { get; init; }

    public IReadOnlyList<BlogCard> Related { get; init; } = Array.Empty<BlogCard>();
}

public static class BlogUrls
{
    public const int PageSize = 9;

    public static bool IsSlug(string? slug)
    {
        if (string.IsNullOrEmpty(slug) || slug.Length > 120)
            return false;
        if (slug[0] == '-' || slug[^1] == '-')
            return false;
        var dash = false;
        foreach (var ch in slug)
        {
            var ok = ch is >= 'a' and <= 'z' or >= '0' and <= '9';
            if (ok)
            {
                dash = false;
                continue;
            }
            if (ch != '-' || dash)
                return false;
            dash = true;
        }
        return true;
    }

    public static string Slugify(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "";
        var sb = new StringBuilder();
        var dash = false;
        foreach (var ch in value.Trim().ToLowerInvariant())
        {
            if (ch is >= 'a' and <= 'z' or >= '0' and <= '9')
            {
                sb.Append(ch);
                dash = false;
            }
            else if (!dash && sb.Length > 0)
            {
                sb.Append('-');
                dash = true;
            }
        }
        var slug = sb.ToString().Trim('-');
        return slug.Length > 120 ? slug[..120].Trim('-') : slug;
    }

    /// <summary>
    /// Route words under /blog are listing pages, so a story cannot publish at those paths.
    /// </summary>
    public static string PublicSlug(string slug)
        => slug is "page" or "category" or "archive" or "index" ? slug + "-story" : slug;

    public static string Listing(int page, string? categorySlug, int? year, int? month)
    {
        string path;
        if (!string.IsNullOrEmpty(categorySlug))
            path = "/blog/category/" + categorySlug;
        else if (year is int y && month is int m)
            path = "/blog/archive/" + y.ToString(CultureInfo.InvariantCulture) + "/" + m.ToString(CultureInfo.InvariantCulture);
        else if (year is int yearOnly)
            path = "/blog/archive/" + yearOnly.ToString(CultureInfo.InvariantCulture);
        else
            path = "/blog";

        if (page > 1)
            path += "/page/" + page.ToString(CultureInfo.InvariantCulture);
        return path;
    }

    /// <summary>
    /// Clean blog URL for a redirect, or null when the request is already canonical.
    /// </summary>
    public static string? CleanTarget(string? path, string? query)
    {
        var raw = string.IsNullOrEmpty(path) ? "/" : path;
        if (!raw.StartsWith('/'))
            raw = "/" + raw;
        var trimmed = raw.Length > 1 ? raw.TrimEnd('/') : raw;
        var lower = trimmed.ToLowerInvariant();
        var q = ParseQuery(query);

        if (q.TryGetValue("post", out var postRaw))
        {
            var post = PublicSlug(Slugify(postRaw));
            if (IsSlug(post))
            {
                var dest = LegacyPathMap.OldBlogSlugs.Contains(post) ? "/blog" : "/blog/" + post;
                return Same(trimmed, query, dest) ? null : dest;
            }
        }

        if (!lower.StartsWith("/blog", StringComparison.Ordinal))
            return null;

        if (!TryRead(lower, out var kind, out var page, out var category, out var year, out var month, out var slug))
            return null;

        string preferred;
        if (kind == BlogKind.Post)
            preferred = LegacyPathMap.OldBlogSlugs.Contains(slug) ? "/blog" : "/blog/" + PublicSlug(slug);
        else
        {
            if (kind == BlogKind.Listing && q.Count > 0)
            {
                if (string.IsNullOrEmpty(category) && q.TryGetValue("category", out var qCategory))
                {
                    var folded = Slugify(qCategory);
                    if (IsSlug(folded))
                        category = folded;
                }
                if (year == null && int.TryParse(q.GetValueOrDefault("year"), NumberStyles.None, CultureInfo.InvariantCulture, out var qYear) && qYear is >= 1990 and <= 2100)
                    year = qYear;
                if (month == null && int.TryParse(q.GetValueOrDefault("month"), NumberStyles.None, CultureInfo.InvariantCulture, out var qMonth) && qMonth is >= 1 and <= 12)
                    month = qMonth;
                if (page <= 1 && int.TryParse(q.GetValueOrDefault("page"), NumberStyles.None, CultureInfo.InvariantCulture, out var qPage) && qPage > 1)
                    page = qPage;
            }

            if (page < 1)
                page = 1;
            preferred = Listing(page, category, year, month);
        }

        return Same(trimmed, query, preferred) ? null : preferred;
    }

    private static bool Same(string trimmed, string? query, string preferred)
        => string.Equals(trimmed, preferred, StringComparison.Ordinal) && !HasQuery(query);

    private static bool HasQuery(string? query)
    {
        if (string.IsNullOrEmpty(query))
            return false;
        var bare = query[0] == '?' ? query[1..] : query;
        return bare.Length > 0;
    }

    private static bool TryRead(string lower, out BlogKind kind, out int page, out string? category, out int? year, out int? month, out string slug)
    {
        kind = BlogKind.Listing;
        page = 1;
        category = null;
        year = null;
        month = null;
        slug = "";
        var parts = lower.Split('/', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0 || parts[0] != "blog")
            return false;
        if (parts.Length == 1)
            return true;

        if (parts[1] == "index" && parts.Length == 2)
            return true;

        if (parts[1] == "page")
        {
            if (parts.Length == 3 && int.TryParse(parts[2], NumberStyles.None, CultureInfo.InvariantCulture, out page))
                return true;
            page = 1;
            return true;
        }

        if (parts[1] == "category")
        {
            if (parts.Length < 3 || !IsSlug(parts[2]))
                return false;
            category = parts[2];
            if (parts.Length == 3)
                return true;
            if (parts.Length == 5 && parts[3] == "page" && int.TryParse(parts[4], NumberStyles.None, CultureInfo.InvariantCulture, out page))
                return true;
            return false;
        }

        if (parts[1] == "archive")
        {
            if (parts.Length < 3 || !int.TryParse(parts[2], NumberStyles.None, CultureInfo.InvariantCulture, out var y))
                return false;
            year = y;
            if (parts.Length == 3)
                return true;
            if (parts.Length == 4 && parts[3] == "page")
            {
                page = 1;
                return true;
            }
            if (parts.Length == 5 && parts[3] == "page" && int.TryParse(parts[4], NumberStyles.None, CultureInfo.InvariantCulture, out page))
                return true;
            if (!int.TryParse(parts[3], NumberStyles.None, CultureInfo.InvariantCulture, out var m))
                return false;
            month = m;
            if (parts.Length == 4)
                return true;
            if (parts.Length == 6 && parts[4] == "page" && int.TryParse(parts[5], NumberStyles.None, CultureInfo.InvariantCulture, out page))
                return true;
            return false;
        }

        if (parts.Length == 2 && IsSlug(parts[1]))
        {
            kind = BlogKind.Post;
            slug = parts[1];
            return true;
        }

        return false;
    }

    private static Dictionary<string, string> ParseQuery(string? query)
    {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (string.IsNullOrEmpty(query))
            return map;
        var bare = query[0] == '?' ? query[1..] : query;
        foreach (var pair in bare.Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var eq = pair.IndexOf('=');
            var key = eq >= 0 ? pair[..eq] : pair;
            var value = eq >= 0 ? pair[(eq + 1)..] : "";
            key = Decode(key);
            if (key.Length == 0 || map.ContainsKey(key))
                continue;
            map[key] = Decode(value);
        }
        return map;
    }

    private static string Decode(string value)
        => Uri.UnescapeDataString(value.Replace("+", " ", StringComparison.Ordinal));

    private enum BlogKind
    {
        Listing,
        Post
    }
}

public static class BlogCatalog
{
    public static IReadOnlyList<BlogCard> Merge(IEnumerable<SoroArticle>? soro, IEnumerable<Blog>? cms)
    {
        var cards = new List<BlogCard>();
        var used = new HashSet<string>(StringComparer.Ordinal);

        if (soro != null)
        {
            foreach (var article in soro)
            {
                var slug = BlogUrls.PublicSlug(article.Slug);
                if (!BlogUrls.IsSlug(slug) || LegacyPathMap.OldBlogSlugs.Contains(slug) || !used.Add(slug))
                    continue;
                cards.Add(new BlogCard
                {
                    Slug = slug,
                    Title = article.Title,
                    Excerpt = article.Excerpt,
                    ImageUrl = article.ImageUrl,
                    Published = article.Published,
                    Source = "soro",
                    ExternalId = article.Id
                });
            }
        }

        if (cms != null)
        {
            foreach (var row in cms)
            {
                if (row == null || !row.IsPublished)
                    continue;
                var title = (row.Title ?? "").Trim();
                if (title.Length == 0)
                    continue;
                var slug = BlogUrls.PublicSlug(BlogUrls.Slugify(string.IsNullOrWhiteSpace(row.Slug) ? title : row.Slug));
                if (!BlogUrls.IsSlug(slug) || LegacyPathMap.OldBlogSlugs.Contains(slug))
                    slug = "post-" + row.Id.ToString(CultureInfo.InvariantCulture);
                if (!used.Add(slug))
                {
                    slug = "post-" + row.Id.ToString(CultureInfo.InvariantCulture);
                    if (!used.Add(slug))
                        continue;
                }

                var category = string.IsNullOrWhiteSpace(row.CategoryName) ? null : row.CategoryName.Trim();
                var published = row.DateCreated == default
                    ? DateTimeOffset.UnixEpoch
                    : new DateTimeOffset(DateTime.SpecifyKind(row.DateCreated, DateTimeKind.Utc));
                cards.Add(new BlogCard
                {
                    Slug = slug,
                    Title = title,
                    Excerpt = BlogHtml.Excerpt(row.Summary, row.Description),
                    ImageUrl = BlogHtml.SafeImage(row.FeaturedImage),
                    Published = published,
                    Category = category,
                    CategorySlug = BlogUrls.IsSlug(BlogUrls.Slugify(category)) ? BlogUrls.Slugify(category) : null,
                    Source = "cms",
                    ExternalId = row.Id.ToString(CultureInfo.InvariantCulture)
                });
            }
        }

        cards.Sort(static (a, b) =>
        {
            var byDate = b.Published.CompareTo(a.Published);
            if (byDate != 0)
                return byDate;
            var byTitle = string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase);
            return byTitle != 0 ? byTitle : string.Compare(a.Slug, b.Slug, StringComparison.Ordinal);
        });
        return cards;
    }

    public static BlogPage Slice(IReadOnlyList<BlogCard> all, int page, string? categorySlug, int? year, int? month)
    {
        all ??= Array.Empty<BlogCard>();
        if (page < 1)
            page = 1;

        var known = true;
        string? categoryName = null;
        IReadOnlyList<BlogCard> filtered = all;
        if (!string.IsNullOrEmpty(categorySlug))
        {
            var matches = all.Where(p => p.CategorySlug == categorySlug).ToList();
            known = matches.Count > 0;
            categoryName = matches.FirstOrDefault()?.Category;
            filtered = matches;
        }
        else if (year != null)
        {
            if (year is < 1990 or > 2100 || month is < 1 or > 12)
                known = false;
            var matches = all.Where(p => p.Published.Year == year && (month == null || p.Published.Month == month)).ToList();
            if (matches.Count == 0)
                known = false;
            filtered = matches;
        }

        var total = filtered.Count;
        var totalPages = total == 0 ? 1 : (int)Math.Ceiling(total / (double)BlogUrls.PageSize);
        IReadOnlyList<BlogCard> posts = !known || page > totalPages
            ? Array.Empty<BlogCard>()
            : filtered.Skip((page - 1) * BlogUrls.PageSize).Take(BlogUrls.PageSize).ToList();
        var path = BlogUrls.Listing(page, categorySlug, year, month);
        var showNav = known && total > BlogUrls.PageSize;

        return new BlogPage
        {
            Posts = posts,
            PageNumber = page,
            Total = total,
            TotalPages = known ? totalPages : 0,
            Known = known,
            CategorySlug = categorySlug,
            CategoryName = categoryName,
            Year = year,
            Month = month,
            Path = path,
            PrevPath = showNav && page > 1 ? BlogUrls.Listing(page - 1, categorySlug, year, month) : null,
            NextPath = showNav && page < totalPages ? BlogUrls.Listing(page + 1, categorySlug, year, month) : null,
            Categories = Categories(all, categorySlug),
            Archives = Archives(all, year, month),
            Heading = Heading(categoryName, year, month, page)
        };
    }

    public static BlogArticle? Article(IReadOnlyList<BlogCard> all, string slug, string html, bool bodyUnavailable)
    {
        if (!BlogUrls.IsSlug(slug))
            return null;
        var index = -1;
        for (var i = 0; i < all.Count; i++)
        {
            if (all[i].Slug == slug)
            {
                index = i;
                break;
            }
        }
        if (index < 0)
            return null;

        var post = all[index];
        var related = new List<BlogCard>();
        if (!string.IsNullOrEmpty(post.CategorySlug))
        {
            foreach (var card in all)
            {
                if (card.Slug != slug && card.CategorySlug == post.CategorySlug)
                    related.Add(card);
                if (related.Count == 3)
                    break;
            }
        }
        if (related.Count < 3)
        {
            foreach (var card in all)
            {
                if (card.Slug == slug || related.Any(r => r.Slug == card.Slug))
                    continue;
                related.Add(card);
                if (related.Count == 3)
                    break;
            }
        }

        return new BlogArticle
        {
            Post = post,
            Html = html,
            BodyUnavailable = bodyUnavailable,
            Newer = index > 0 ? all[index - 1] : null,
            Older = index + 1 < all.Count ? all[index + 1] : null,
            Related = related
        };
    }

    private static IReadOnlyList<BlogFacet> Categories(IReadOnlyList<BlogCard> all, string? selected)
    {
        return all
            .Where(p => !string.IsNullOrEmpty(p.CategorySlug))
            .GroupBy(p => p.CategorySlug!)
            .Select(group => new BlogFacet
            {
                Label = group.Select(p => p.Category).FirstOrDefault(name => !string.IsNullOrWhiteSpace(name)) ?? group.Key,
                Path = BlogUrls.Listing(1, group.Key, null, null),
                Count = group.Count(),
                Selected = group.Key == selected
            })
            .OrderByDescending(f => f.Count)
            .ThenBy(f => f.Label, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<BlogFacet> Archives(IReadOnlyList<BlogCard> all, int? year, int? month)
    {
        return all
            .Where(p => p.Published.Year >= 1990)
            .GroupBy(p => (p.Published.Year, p.Published.Month))
            .OrderByDescending(group => group.Key.Year)
            .ThenByDescending(group => group.Key.Month)
            .Select(group => new BlogFacet
            {
                Label = new DateTime(group.Key.Year, group.Key.Month, 1).ToString("MMMM yyyy", CultureInfo.InvariantCulture),
                Path = BlogUrls.Listing(1, null, group.Key.Year, group.Key.Month),
                Count = group.Count(),
                Selected = year == group.Key.Year && month == group.Key.Month
            })
            .ToList();
    }

    private static string Heading(string? categoryName, int? year, int? month, int page)
    {
        string title;
        if (!string.IsNullOrEmpty(categoryName))
            title = categoryName;
        else if (year is int y && month is int m && m is >= 1 and <= 12)
            title = new DateTime(y, m, 1).ToString("MMMM yyyy", CultureInfo.InvariantCulture);
        else if (year is int yearOnly)
            title = yearOnly.ToString(CultureInfo.InvariantCulture);
        else
            title = "Wally's blog";
        return page > 1 ? title + ", page " + page.ToString(CultureInfo.InvariantCulture) : title;
    }
}

public static class BlogHtml
{
    private static readonly Regex Script = new("<script\\b[^>]*>.*?</script>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
    private static readonly Regex Style = new("<style\\b[^>]*>.*?</style>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
    private static readonly Regex Blocked = new("</?(?:iframe|object|embed|form|link|meta)\\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    private static readonly Regex Handlers = new("\\s+on[a-z]+\\s*=\\s*(\"[^\"]*\"|'[^']*'|[^\\s>]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    private static readonly Regex Tags = new("<[^>]+>", RegexOptions.Compiled);
    private static readonly Regex Space = new("\\s+", RegexOptions.Compiled);

    public static string Sanitize(string? html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return "";
        var clean = Script.Replace(html, "");
        clean = Style.Replace(clean, "");
        clean = Blocked.Replace(clean, "");
        clean = Handlers.Replace(clean, "");
        clean = Regex.Replace(clean, "javascript\\s*:", "", RegexOptions.IgnoreCase);
        return clean.Trim();
    }

    public static string Excerpt(string? summary, string? html, int max = 220)
    {
        var text = string.IsNullOrWhiteSpace(summary) ? Plain(html) : Space.Replace(summary.Trim(), " ");
        if (text.Length <= max)
            return text;
        var cut = text.LastIndexOf(' ', Math.Min(max, text.Length - 1));
        if (cut < 80)
            cut = max;
        return text[..cut].TrimEnd() + "...";
    }

    public static string Plain(string? html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return "";
        var text = Tags.Replace(html, " ");
        text = WebUtility.HtmlDecode(text);
        return Space.Replace(text, " ").Trim();
    }

    public static string? SafeImage(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return null;
        var trimmed = url.Trim();
        if (trimmed.StartsWith("~/", StringComparison.Ordinal) || (trimmed.StartsWith('/') && !trimmed.StartsWith("//", StringComparison.Ordinal)))
            return trimmed;
        if (Uri.TryCreate(trimmed, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp))
            return trimmed;
        return null;
    }

    public static string ArticleJson(BlogCard post, string origin)
    {
        var data = new Dictionary<string, object?>
        {
            ["@context"] = "https://schema.org",
            ["@type"] = "BlogPosting",
            ["headline"] = post.Title,
            ["description"] = post.Excerpt,
            ["datePublished"] = post.Published.UtcDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture),
            ["mainEntityOfPage"] = origin + post.Path,
            ["author"] = new Dictionary<string, string> { ["@type"] = "Organization", ["name"] = "Wally Wombats" },
            ["publisher"] = new Dictionary<string, string> { ["@type"] = "Organization", ["name"] = "Wally Wombats" }
        };
        if (!string.IsNullOrEmpty(post.ImageUrl) && post.ImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            data["image"] = post.ImageUrl;
        return JsonSerializer.Serialize(data);
    }
}
