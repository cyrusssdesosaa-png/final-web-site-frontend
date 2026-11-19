namespace WallyWombatsPublic_MVC.Seo;

/// <summary>
/// One official site address. Canonical tags, robots.txt, the sitemap, and
/// permanent host redirects all read this value.
/// </summary>
/// <remarks>
/// Default is <c>https://www.wallywombats.com</c>. Google Search Console still
/// treats www as the chosen canonical (homepage last crawled 19 Nov 2026, 6:00 AM
/// Asia/Manila) and almost all clicks still land on www. The Nov 14 2026 switch
/// to the apex host left the apex homepage as "Google chose a different canonical."
/// Set <c>Site:OfficialOrigin</c> only if that choice should change.
/// The scheme is always published as https.
/// </remarks>
public sealed class SiteOptions
{
    public const string DefaultOrigin = "https://www.wallywombats.com";

    public string OfficialOrigin { get; set; } = DefaultOrigin;

    public static string Normalize(string? origin)
    {
        var raw = string.IsNullOrWhiteSpace(origin) ? DefaultOrigin : origin.Trim();
        if (!Uri.TryCreate(raw, UriKind.Absolute, out var uri) || string.IsNullOrEmpty(uri.Host))
            uri = new Uri(DefaultOrigin);

        var builder = new UriBuilder(uri)
        {
            Scheme = Uri.UriSchemeHttps,
            Port = -1
        };
        return builder.Uri.GetLeftPart(UriPartial.Authority);
    }
}
