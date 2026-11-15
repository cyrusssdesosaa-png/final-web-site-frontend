using WallyWombatsPublic_MVC.Models;
using Xunit;

namespace WallyWombatsPublic.Tests;

public class BlogCatalogTests
{
    [Fact]
    public void Parser_reads_articles_and_ignores_a_broken_script()
    {
        const string script = """
            var SORO_ARTICLES = [{"id":"abc","title":"Party \"tips\"","slug":"Party-Tips","excerpt":"A short note","isoDate":"2026-11-15T02:11:56.968+00:00","image":"https://cdn.example/a.webp","content":null}];
            var SORO_TOKEN = 'x';
            """;

        var articles = SoroBlogParser.Parse(script);
        var article = Assert.Single(articles);
        Assert.Equal("abc", article.Id);
        Assert.Equal("Party \"tips\"", article.Title);
        Assert.Equal("party-tips", article.Slug);
        Assert.Equal("A short note", article.Excerpt);
        Assert.Equal(new DateTimeOffset(2026, 11, 15, 2, 11, 56, 968, TimeSpan.Zero), article.Published);
        Assert.Empty(SoroBlogParser.Parse("no articles here"));
    }

    [Fact]
    public void Merge_is_newest_first_and_keeps_each_slug()
    {
        var soro = new[]
        {
            new SoroArticle("1", "Older Soro", "older-soro", "One", null, new DateTimeOffset(2026, 11, 1, 0, 0, 0, TimeSpan.Zero)),
            new SoroArticle("2", "Newest", "newest-story", "Two", "https://cdn.example/a.webp", new DateTimeOffset(2026, 11, 15, 0, 0, 0, TimeSpan.Zero))
        };
        var cms = new[]
        {
            new Blog
            {
                Id = 4,
                IsPublished = true,
                Title = "Club news",
                Slug = "newest-story",
                Summary = "From the club",
                CategoryName = "Play Time",
                DateCreated = new DateTime(2026, 11, 10, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = 5,
                IsPublished = false,
                Title = "Hidden",
                Slug = "hidden-draft",
                DateCreated = new DateTime(2026, 11, 20, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = 6,
                IsPublished = true,
                Title = "Broken old link",
                Slug = "magic-of-laughter-on-kids",
                DateCreated = new DateTime(2026, 10, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        };

        var merged = BlogCatalog.Merge(soro, cms);

        Assert.Equal(new[] { "newest-story", "post-4", "older-soro", "post-6" }, merged.Select(p => p.Slug).ToArray());
        Assert.Equal("play-time", merged.Single(p => p.Slug == "post-4").CategorySlug);
        Assert.DoesNotContain(merged, p => p.Title == "Hidden");
        Assert.DoesNotContain(merged, p => p.Slug == "magic-of-laughter-on-kids");
    }

    [Fact]
    public void Pages_are_nine_posts_newest_first_with_clean_links()
    {
        var posts = Enumerable.Range(1, 10)
            .Select(n => new BlogCard
            {
                Slug = "story-" + n,
                Title = "Story " + n,
                Published = new DateTimeOffset(2026, 1, n, 0, 0, 0, TimeSpan.Zero),
                Category = "Parties",
                CategorySlug = "parties"
            })
            .OrderByDescending(p => p.Published)
            .ToList();

        var page = BlogCatalog.Slice(posts, 2, null, null, null);

        Assert.Equal(2, page.TotalPages);
        Assert.Equal("/blog/page/2", page.Path);
        Assert.Equal("/blog", page.PrevPath);
        Assert.Null(page.NextPath);
        var only = Assert.Single(page.Posts);
        Assert.Equal("story-1", only.Slug);
        var category = Assert.Single(page.Categories);
        Assert.Equal("Parties", category.Label);
        Assert.Equal("/blog/category/parties", category.Path);
        Assert.Contains(page.Archives, a => a.Path == "/blog/archive/2026/1" && a.Count == 10);

        var filtered = BlogCatalog.Slice(posts, 1, "parties", null, null);
        Assert.Equal(10, filtered.Total);
        Assert.Equal("/blog/category/parties", filtered.Path);

        var missing = BlogCatalog.Slice(posts, 1, "nope", null, null);
        Assert.False(missing.Known);

        Assert.Equal("/blog", BlogUrls.Listing(1, null, null, null));
        Assert.Equal("/blog/archive/2026/11/page/3", BlogUrls.Listing(3, null, 2026, 11));
    }

    [Fact]
    public void Clean_urls_redirect_old_post_queries_and_page_one()
    {
        Assert.Equal("/blog/indoor-birthday-party-las-vegas", BlogUrls.CleanTarget("/", "?post=indoor-birthday-party-las-vegas"));
        Assert.Equal("/blog/indoor-birthday-party-las-vegas", BlogUrls.CleanTarget("/blog", "?post=Indoor-Birthday-Party-Las-Vegas"));
        Assert.Equal("/blog", BlogUrls.CleanTarget("/", "?post=magic-of-laughter-on-kids"));
        Assert.Equal("/blog", BlogUrls.CleanTarget("/blog/page/1", ""));
        Assert.Equal("/blog/page/2", BlogUrls.CleanTarget("/blog", "?page=2"));
        Assert.Equal("/blog/category/parties/page/2", BlogUrls.CleanTarget("/blog", "?category=Parties&page=2"));
        Assert.Equal("/blog/archive/2026/11", BlogUrls.CleanTarget("/blog/archive/2026/11/page/1", ""));
        Assert.Null(BlogUrls.CleanTarget("/blog/indoor-birthday-party-las-vegas", ""));
        Assert.Null(BlogUrls.CleanTarget("/blog/page/2", ""));
        Assert.Equal("/blog/indoor-birthday-party-las-vegas", BlogUrls.CleanTarget("/blog/indoor-birthday-party-las-vegas", "?utm_source=soro"));
        Assert.Null(BlogUrls.CleanTarget("/book", "?loc=henderson"));
    }

    [Fact]
    public void Article_html_drops_scripts_and_keeps_the_story()
    {
        var html = BlogHtml.Sanitize("<p>Hello <strong>families</strong></p><script>alert(1)</script><img src=x onerror=\"alert(1)\">");
        Assert.Contains("<p>Hello <strong>families</strong></p>", html);
        Assert.DoesNotContain("script", html, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("onerror", html, StringComparison.OrdinalIgnoreCase);
        Assert.Equal("Hello families", BlogHtml.Plain("<p>Hello <strong>families</strong></p>"));
        Assert.Null(BlogHtml.SafeImage("javascript:alert(1)"));
        Assert.Equal("https://cdn.example/a.webp", BlogHtml.SafeImage("https://cdn.example/a.webp"));
    }

    [Fact]
    public void Article_links_newer_and_older_neighbors()
    {
        var posts = new List<BlogCard>
        {
            new() { Slug = "new", Title = "New", Published = new DateTimeOffset(2026, 11, 15, 0, 0, 0, TimeSpan.Zero) },
            new() { Slug = "mid", Title = "Mid", Published = new DateTimeOffset(2026, 11, 10, 0, 0, 0, TimeSpan.Zero), CategorySlug = "play" },
            new() { Slug = "old", Title = "Old", Published = new DateTimeOffset(2026, 11, 1, 0, 0, 0, TimeSpan.Zero), CategorySlug = "play" }
        };

        var article = BlogCatalog.Article(posts, "mid", "<p>Body</p>", false);
        Assert.NotNull(article);
        Assert.Equal("new", article!.Newer!.Slug);
        Assert.Equal("old", article.Older!.Slug);
        Assert.Contains(article.Related, p => p.Slug == "old");
        Assert.Null(BlogCatalog.Article(posts, "missing", "", false));
    }
}
