using WallyWombatsPublic_MVC.Seo;
using Xunit;

namespace WallyWombatsPublic.Tests;

public class SeoRedirectorTests
{
    private readonly SeoRedirector _seo = new(SiteOptions.DefaultOrigin);

    [Fact]
    public void Localhost_keeps_http_and_only_cleans_the_path()
    {
        var target = _seo.GetRedirectTarget("GET", "http", "localhost:5082", "localhost", "/Book", "");
        Assert.Equal("http://localhost:5082/book", target);

        Assert.Null(_seo.GetRedirectTarget("GET", "http", "localhost:5082", "localhost", "/", ""));
        Assert.Null(_seo.GetRedirectTarget("GET", "http", "127.0.0.1:5082", "127.0.0.1", "/", ""));
        Assert.Null(_seo.GetRedirectTarget("GET", "http", "localhost:5082", "localhost", "/img/Header/favicon.png", ""));
    }

    [Fact]
    public void Public_http_and_www_become_one_https_apex_hop()
    {
        Assert.Equal(
            "https://wallywombats.com/",
            _seo.GetRedirectTarget("GET", "http", "wallywombats.com", "wallywombats.com", "/", ""));

        Assert.Equal(
            "https://wallywombats.com/",
            _seo.GetRedirectTarget("GET", "http", "www.wallywombats.com", "www.wallywombats.com", "/", ""));

        Assert.Equal(
            "https://wallywombats.com/book",
            _seo.GetRedirectTarget("GET", "https", "www.wallywombats.com", "www.wallywombats.com", "/book", ""));

        Assert.Null(_seo.GetRedirectTarget("GET", "https", "wallywombats.com", "wallywombats.com", "/book", ""));
    }

    [Fact]
    public void Trailing_slash_case_and_home_aliases_301_in_one_hop()
    {
        Assert.Equal("https://wallywombats.com/book", Redirect("/book/"));
        Assert.Equal("https://wallywombats.com/privacy-policy", Redirect("/Privacy-Policy"));
        Assert.Equal("https://wallywombats.com/friends/wally", Redirect("/Friends/Wally"));
        Assert.Equal("https://wallywombats.com/book/las-vegas", Redirect("/book/Las-Vegas"));
        Assert.Equal("https://wallywombats.com/locations/henderson", Redirect("/Locations/Henderson"));
        Assert.Equal("https://wallywombats.com/", Redirect("/Home"));
        Assert.Equal("https://wallywombats.com/", Redirect("/Home/Index"));
        Assert.Equal("https://wallywombats.com/", Redirect("/home"));
        Assert.Equal("https://wallywombats.com/", Redirect("/index.html"));
        Assert.Equal("https://wallywombats.com/faq", Redirect("/Home/FAQs"));
    }

    [Fact]
    public void Broken_blog_urls_go_to_blog_without_the_old_query()
    {
        Assert.Equal("https://wallywombats.com/blog", Redirect("/post", "?id=1&catname=Play"));
        Assert.Equal("https://wallywombats.com/blog", Redirect("/post"));
        Assert.Equal("https://wallywombats.com/blog", Redirect("/Home/MoreBlogPost"));
        Assert.Equal("https://wallywombats.com/blog", Redirect("/blog/magic-of-laughter-on-kids"));
        Assert.Equal("https://wallywombats.com/blog", Redirect("/posts/"));
        Assert.Null(Redirect("/blog/indoor-birthday-party-las-vegas"));
    }

    [Fact]
    public void Legacy_marketing_urls_point_at_pages_this_site_serves()
    {
        Assert.Equal("https://wallywombats.com/book", Redirect("/birthday-parties/"));
        Assert.Equal("https://wallywombats.com/book/henderson", Redirect("/birthday-parties-henderson/"));
        Assert.Equal("https://wallywombats.com/book/las-vegas", Redirect("/birthday_parties_north_rainbow/"));
        Assert.Equal("https://wallywombats.com/contact-us", Redirect("/contact/"));
        Assert.Equal("https://wallywombats.com/faq", Redirect("/faqs/"));
        Assert.Equal("https://wallywombats.com/#playground", Redirect("/the-playground/"));
        Assert.Equal("https://wallywombats.com/book/henderson", Redirect("/playground-prices-henderson/"));
        Assert.Equal("https://wallywombats.com/book/las-vegas", Redirect("/playground-prices-north-rainbow/"));
        Assert.Equal("https://wallywombats.com/book/las-vegas", Redirect("/playground_prices_north_rainbow/"));
        Assert.Equal("https://wallywombats.com/pricing", Redirect("/prices/"));
        Assert.Equal("https://wallywombats.com/about-us", Redirect("/about"));
        Assert.Equal("https://wallywombats.com/privacy-policy", Redirect("/PrivacyPolicy"));
        Assert.Equal("https://wallywombats.com/#crew", Redirect("/friends/"));
        Assert.Null(Redirect("/friends/wally"));
        Assert.Null(Redirect("/book/las-vegas"));
        Assert.Null(Redirect("/book/henderson"));
        Assert.Null(Redirect("/book/bullhead-city"));
        Assert.Equal("https://wallywombats.com/#locations", Redirect("/locations"));
        Assert.Equal("https://wallywombats.com/#locations", Redirect("/Locations"));
        Assert.Equal("https://wallywombats.com/book/las-vegas", Redirect("/book/north-rainbow"));
        Assert.Equal("https://wallywombats.com/#contact", Redirect("/subscribe"));
        Assert.Equal("https://wallywombats.com/#contact", Redirect("/Home/SendEmail_Index"));
    }

    [Fact]
    public void Post_is_not_redirected_and_static_assets_keep_their_casing()
    {
        Assert.Null(_seo.GetRedirectTarget("POST", "https", "www.wallywombats.com", "www.wallywombats.com", "/Home/SendEmail_Index", ""));
        Assert.Null(_seo.GetRedirectTarget("POST", "http", "wallywombats.com", "wallywombats.com", "/subscribe", ""));
        Assert.Equal(
            "https://wallywombats.com/img/Header/favicon.png",
            _seo.GetRedirectTarget("GET", "http", "www.wallywombats.com", "www.wallywombats.com", "/img/Header/favicon.png", ""));
    }

    [Fact]
    public void Canonical_uses_the_official_origin_and_drops_blog_query_junk()
    {
        Assert.Equal("https://wallywombats.com/", _seo.CanonicalHref("/"));
        Assert.Equal("https://wallywombats.com/book", _seo.CanonicalHref("/Book/"));
        Assert.Equal("https://wallywombats.com/", _seo.CanonicalHref("/Home/Index"));
        Assert.Equal("https://wallywombats.com/locations/las-vegas", _seo.CanonicalHref("/Locations/las-vegas"));
        Assert.Equal("https://wallywombats.com/book/henderson", _seo.CanonicalHref("/book/henderson"));
        Assert.Equal("https://wallywombats.com/friends/ney-ney", _seo.CanonicalHref("/friends/ney-ney"));
    }

    [Fact]
    public void Www_setting_is_honored_when_configured()
    {
        var www = new SeoRedirector("https://www.wallywombats.com");
        Assert.Equal("https://www.wallywombats.com", www.Origin);
        Assert.Equal(
            "https://www.wallywombats.com/book",
            www.GetRedirectTarget("GET", "https", "wallywombats.com", "wallywombats.com", "/book", ""));
    }

    [Fact]
    public void Sitemap_lists_book_and_friend_pages_and_skips_soro_posts()
    {
        var xml = SitemapXml.Build(
            SiteOptions.DefaultOrigin,
            new[] { "las-vegas", "henderson", "bullhead-city" },
            SitemapXml.DefaultFriendSlugs);

        Assert.Contains("https://wallywombats.com/book/las-vegas", xml);
        Assert.Contains("https://wallywombats.com/book/henderson", xml);
        Assert.Contains("https://wallywombats.com/book/bullhead-city", xml);
        Assert.Contains("https://wallywombats.com/locations/las-vegas", xml);
        Assert.Contains("https://wallywombats.com/friends/wally", xml);
        Assert.Contains("https://wallywombats.com/friends/bunski", xml);
        Assert.Contains("https://wallywombats.com/friends/don-don", xml);
        Assert.Contains("https://wallywombats.com/friends/len-len", xml);
        Assert.Contains("https://wallywombats.com/friends/ney-ney", xml);
        Assert.DoesNotContain("indoor-birthday-party-las-vegas", xml);
        Assert.DoesNotContain("/post", xml);
        Assert.DoesNotContain("www.wallywombats.com", xml);
    }

    private string? Redirect(string path, string query = "")
        => _seo.GetRedirectTarget("GET", "https", "wallywombats.com", "wallywombats.com", path, query);
}
