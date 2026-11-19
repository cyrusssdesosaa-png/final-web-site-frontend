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
    public void Public_http_and_apex_become_one_https_www_hop()
    {
        Assert.Equal(
            "https://www.wallywombats.com/",
            _seo.GetRedirectTarget("GET", "http", "wallywombats.com", "wallywombats.com", "/", ""));

        Assert.Equal(
            "https://www.wallywombats.com/",
            _seo.GetRedirectTarget("GET", "http", "www.wallywombats.com", "www.wallywombats.com", "/", ""));

        Assert.Equal(
            "https://www.wallywombats.com/book",
            _seo.GetRedirectTarget("GET", "https", "wallywombats.com", "wallywombats.com", "/book", ""));

        Assert.Null(_seo.GetRedirectTarget("GET", "https", "www.wallywombats.com", "www.wallywombats.com", "/book", ""));
    }

    [Fact]
    public void Trailing_slash_case_and_home_aliases_301_in_one_hop()
    {
        Assert.Equal("https://www.wallywombats.com/book", Redirect("/book/"));
        Assert.Equal("https://www.wallywombats.com/privacy-policy", Redirect("/Privacy-Policy"));
        Assert.Equal("https://www.wallywombats.com/friends/wally", Redirect("/Friends/Wally"));
        Assert.Equal("https://www.wallywombats.com/book/las-vegas", Redirect("/book/Las-Vegas"));
        Assert.Equal("https://www.wallywombats.com/locations/henderson", Redirect("/Locations/Henderson"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/Home"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/Home/Index"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/home"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/index.html"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/index.php"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/default.aspx"));
        Assert.Equal("https://www.wallywombats.com/faq", Redirect("/Home/FAQs"));
        Assert.Equal("https://www.wallywombats.com/apps", Redirect("/mobile-app"));
    }

    [Fact]
    public void Broken_blog_urls_go_to_blog_without_the_old_query()
    {
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/post", "?id=1&catname=Play"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/post"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/Home/MoreBlogPost"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/blog/magic-of-laughter-on-kids"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/blog/parents-guide-to-choosing-perfect-christmas-gift"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/blog/playing-with-kids-on-spectrum"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/blog/guide-to-childrens-party-packages"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/posts/"));
        Assert.Null(Redirect("/blog/indoor-birthday-party-las-vegas"));
        Assert.Equal("https://www.wallywombats.com/blog/indoor-birthday-party-las-vegas", Redirect("/", "?post=indoor-birthday-party-las-vegas"));
        Assert.Equal("https://www.wallywombats.com/blog/indoor-birthday-party-las-vegas", Redirect("/", "?presets=preset2&post=indoor-birthday-party-las-vegas"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/", "?post=guide-to-childrens-party-packages"));
        Assert.Equal("https://www.wallywombats.com/blog", Redirect("/blog/page/1"));
        Assert.Equal("https://www.wallywombats.com/blog/page/2", Redirect("/blog", "?page=2"));
        Assert.Null(Redirect("/blog/page/2"));
    }

    [Fact]
    public void Homepage_junk_query_strings_301_to_the_clean_url()
    {
        Assert.Equal("https://www.wallywombats.com/", Redirect("/", "?presets=preset1"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/", "?presets=preset8"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/", "?from=AppAgg.com"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/", "?s={search_term_string}"));
        Assert.Equal("https://www.wallywombats.com/", Redirect("/", "?s=test"));
        Assert.Equal("https://www.wallywombats.com/book", Redirect("/book", "?utm_source=soro"));
        Assert.Null(Redirect("/book", "?loc=henderson"));
        Assert.Equal(
            "https://www.wallywombats.com/blog/things-to-do-with-toddlers-las-vegas",
            Redirect("/", "?presets=preset2&post=things-to-do-with-toddlers-las-vegas"));
    }

    [Fact]
    public void Retired_wordpress_author_and_admin_paths_are_gone()
    {
        Assert.True(SeoRedirector.IsGone("/author/richardelectricpixels-com/"));
        Assert.True(SeoRedirector.IsGone("/author/richardelectricpixels-com"));
        Assert.True(SeoRedirector.IsGone("/author"));
        Assert.True(SeoRedirector.IsGone("/wp-login.php"));
        Assert.True(SeoRedirector.IsGone("/wp-admin/"));
        Assert.False(SeoRedirector.IsGone("/about-us"));
        Assert.False(SeoRedirector.IsGone("/blog/category/parties"));
    }

    [Fact]
    public void Legacy_marketing_urls_point_at_pages_this_site_serves()
    {
        Assert.Equal("https://www.wallywombats.com/book", Redirect("/birthday-parties/"));
        Assert.Equal("https://www.wallywombats.com/book/henderson", Redirect("/birthday-parties-henderson/"));
        Assert.Equal("https://www.wallywombats.com/book/las-vegas", Redirect("/birthday_parties_north_rainbow/"));
        Assert.Equal("https://www.wallywombats.com/contact-us", Redirect("/contact/"));
        Assert.Equal("https://www.wallywombats.com/faq", Redirect("/faqs/"));
        Assert.Equal("https://www.wallywombats.com/#playground", Redirect("/the-playground/"));
        Assert.Equal("https://www.wallywombats.com/#playground", Redirect("/playground"));
        Assert.Equal("https://www.wallywombats.com/book/henderson", Redirect("/playground-prices-henderson/"));
        Assert.Equal("https://www.wallywombats.com/book/las-vegas", Redirect("/playground-prices-north-rainbow/"));
        Assert.Equal("https://www.wallywombats.com/book/las-vegas", Redirect("/playground_prices_north_rainbow/"));
        Assert.Equal("https://www.wallywombats.com/pricing", Redirect("/prices/"));
        Assert.Equal("https://www.wallywombats.com/about-us", Redirect("/about"));
        Assert.Equal("https://www.wallywombats.com/privacy-policy", Redirect("/PrivacyPolicy"));
        Assert.Equal("https://www.wallywombats.com/#crew", Redirect("/friends/"));
        Assert.Null(Redirect("/friends/wally"));
        Assert.Null(Redirect("/book/las-vegas"));
        Assert.Null(Redirect("/book/henderson"));
        Assert.Null(Redirect("/book/bullhead-city"));
        Assert.Equal("https://www.wallywombats.com/#locations", Redirect("/locations"));
        Assert.Equal("https://www.wallywombats.com/#locations", Redirect("/Locations"));
        Assert.Equal("https://www.wallywombats.com/book/las-vegas", Redirect("/book/north-rainbow"));
        Assert.Equal("https://www.wallywombats.com/#contact", Redirect("/subscribe"));
        Assert.Equal("https://www.wallywombats.com/#contact", Redirect("/Home/SendEmail_Index"));
    }

    [Fact]
    public void Post_is_not_redirected_and_static_assets_keep_their_casing()
    {
        Assert.Null(_seo.GetRedirectTarget("POST", "https", "wallywombats.com", "wallywombats.com", "/Home/SendEmail_Index", ""));
        Assert.Null(_seo.GetRedirectTarget("POST", "http", "www.wallywombats.com", "www.wallywombats.com", "/subscribe", ""));
        Assert.Equal(
            "https://www.wallywombats.com/img/Header/favicon.png",
            _seo.GetRedirectTarget("GET", "http", "www.wallywombats.com", "www.wallywombats.com", "/img/Header/favicon.png", ""));
    }

    [Fact]
    public void Canonical_uses_the_official_origin_and_drops_blog_query_junk()
    {
        Assert.Equal("https://www.wallywombats.com/", _seo.CanonicalHref("/"));
        Assert.Equal("https://www.wallywombats.com/book", _seo.CanonicalHref("/Book/"));
        Assert.Equal("https://www.wallywombats.com/", _seo.CanonicalHref("/Home/Index"));
        Assert.Equal("https://www.wallywombats.com/locations/las-vegas", _seo.CanonicalHref("/Locations/las-vegas"));
        Assert.Equal("https://www.wallywombats.com/book/henderson", _seo.CanonicalHref("/book/henderson"));
        Assert.Equal("https://www.wallywombats.com/friends/ney-ney", _seo.CanonicalHref("/friends/ney-ney"));
    }

    [Fact]
    public void Apex_setting_is_honored_when_configured()
    {
        var apex = new SeoRedirector("https://wallywombats.com");
        Assert.Equal("https://wallywombats.com", apex.Origin);
        Assert.Equal(
            "https://wallywombats.com/book",
            apex.GetRedirectTarget("GET", "https", "www.wallywombats.com", "www.wallywombats.com", "/book", ""));
    }

    [Fact]
    public void Sitemap_lists_book_and_friend_pages_and_skips_soro_posts()
    {
        var xml = SitemapXml.Build(
            SiteOptions.DefaultOrigin,
            new[] { "las-vegas", "henderson", "bullhead-city" },
            SitemapXml.DefaultFriendSlugs);

        Assert.Contains("https://www.wallywombats.com/book/las-vegas", xml);
        Assert.Contains("https://www.wallywombats.com/book/henderson", xml);
        Assert.Contains("https://www.wallywombats.com/book/bullhead-city", xml);
        Assert.Contains("https://www.wallywombats.com/locations/las-vegas", xml);
        Assert.Contains("https://www.wallywombats.com/friends/wally", xml);
        Assert.Contains("https://www.wallywombats.com/friends/bunski", xml);
        Assert.Contains("https://www.wallywombats.com/friends/don-don", xml);
        Assert.Contains("https://www.wallywombats.com/friends/len-len", xml);
        Assert.Contains("https://www.wallywombats.com/friends/ney-ney", xml);
        Assert.DoesNotContain("indoor-birthday-party-las-vegas", xml);
        Assert.DoesNotContain("/post", xml);
        Assert.DoesNotContain("https://wallywombats.com/", xml);

        var withPosts = SitemapXml.Build(
            SiteOptions.DefaultOrigin,
            new[] { "las-vegas" },
            SitemapXml.DefaultFriendSlugs,
            new[] { "indoor-birthday-party-las-vegas", "page", "not a slug" });
        Assert.Contains("https://www.wallywombats.com/blog/indoor-birthday-party-las-vegas", withPosts);
        Assert.DoesNotContain("/blog/page<", withPosts);
        Assert.DoesNotContain("not a slug", withPosts);
    }

    private string? Redirect(string path, string query = "")
        => _seo.GetRedirectTarget("GET", "https", "www.wallywombats.com", "www.wallywombats.com", path, query);
}
