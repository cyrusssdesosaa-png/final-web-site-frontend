namespace WallyWombatsPublic_MVC.Seo;

/// <summary>
/// One official site address. Canonical tags, robots.txt, the sitemap, and
/// permanent host redirects all read this value.
/// </summary>
/// <remarks>
/// Default is the apex <c>https://wallywombats.com</c>. The 2021–2022 WordPress
/// site preferred www, but the current ASP.NET app and the live site serve both
/// hosts with no preference in code. Set <c>Site:OfficialOrigin</c> to
/// <c>https://www.wallywombats.com</c> if www should be official instead.
/// The scheme is always published as https.
/// </remarks>
public sealed class SiteOptions
{
    public const string DefaultOrigin = "https://wallywombats.com";

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
