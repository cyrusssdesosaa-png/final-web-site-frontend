using Microsoft.EntityFrameworkCore;

namespace WallyWombatsPublic_MVC.Models;

public sealed class BlogFeed
{
    private readonly SoroBlogClient _soro;
    private readonly WWContext _db;
    private readonly ILogger<BlogFeed> _logger;

    public BlogFeed(SoroBlogClient soro, WWContext db, ILogger<BlogFeed> logger)
    {
        _soro = soro;
        _db = db;
        _logger = logger;
    }

    public async Task<IReadOnlyList<BlogCard>> AllAsync(CancellationToken cancellationToken)
    {
        var soro = await _soro.GetArticlesAsync(cancellationToken);
        List<Blog> cms = new();
        try
        {
            cms = await _db.Blog.AsNoTracking().Where(row => row.IsPublished).ToListAsync(cancellationToken);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _logger.LogWarning(ex, "Published blog rows could not be read.");
        }

        return BlogCatalog.Merge(soro, cms);
    }

    public async Task<IReadOnlyList<BlogCard>> LatestAsync(int count, CancellationToken cancellationToken)
    {
        if (count < 1)
            return Array.Empty<BlogCard>();
        var all = await AllAsync(cancellationToken);
        return all.Take(count).ToList();
    }

    public async Task<BlogPage> PageAsync(int page, string? categorySlug, int? year, int? month, CancellationToken cancellationToken)
    {
        var all = await AllAsync(cancellationToken);
        return BlogCatalog.Slice(all, page, categorySlug, year, month);
    }

    public async Task<BlogArticle?> ArticleAsync(string slug, CancellationToken cancellationToken)
    {
        var all = await AllAsync(cancellationToken);
        BlogCard? card = null;
        foreach (var item in all)
        {
            if (item.Slug == slug)
            {
                card = item;
                break;
            }
        }
        if (card == null)
            return null;

        string html;
        var unavailable = false;
        if (card.Source == "soro")
        {
            var body = await _soro.GetArticleHtmlAsync(card.ExternalId, cancellationToken);
            if (string.IsNullOrWhiteSpace(body))
            {
                unavailable = true;
                html = "";
            }
            else
            {
                html = BlogHtml.Sanitize(body);
            }
        }
        else
        {
            html = "";
            try
            {
                var id = int.TryParse(card.ExternalId, out var parsed) ? parsed : 0;
                var row = await _db.Blog.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
                html = BlogHtml.Sanitize(row?.Description);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _logger.LogWarning(ex, "Blog post {Slug} could not be read.", slug);
                unavailable = true;
            }
        }

        return BlogCatalog.Article(all, slug, html, unavailable);
    }
}
