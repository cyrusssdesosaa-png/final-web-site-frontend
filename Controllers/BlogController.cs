using Microsoft.AspNetCore.Mvc;
using WallyWombatsPublic_MVC.Models;

namespace WallyWombatsPublic_MVC.Controllers;

public class BlogController : Controller
{
    private readonly BlogFeed _blog;

    public BlogController(BlogFeed blog) => _blog = blog;

    [HttpGet("/blog")]
    [HttpGet("/blog/page/{page:int}")]
    public Task<IActionResult> Index(int page = 1, CancellationToken cancellationToken = default)
        => Listing(page, null, null, null, cancellationToken);

    [HttpGet("/blog/category/{category}")]
    [HttpGet("/blog/category/{category}/page/{page:int}")]
    public Task<IActionResult> Category(string category, int page = 1, CancellationToken cancellationToken = default)
        => Listing(page, category, null, null, cancellationToken);

    [HttpGet("/blog/archive/{year:int}")]
    [HttpGet("/blog/archive/{year:int}/page/{page:int}")]
    [HttpGet("/blog/archive/{year:int}/{month:int}")]
    [HttpGet("/blog/archive/{year:int}/{month:int}/page/{page:int}")]
    public Task<IActionResult> Archive(int year, int? month, int page = 1, CancellationToken cancellationToken = default)
        => Listing(page, null, year, month, cancellationToken);

    [HttpGet("/blog/{slug}")]
    public async Task<IActionResult> Post(string slug, CancellationToken cancellationToken)
    {
        if (!BlogUrls.IsSlug(slug) || slug is "page" or "category" or "archive" or "index")
            return NotFound();

        var article = await _blog.ArticleAsync(slug, cancellationToken);
        if (article == null)
            return RedirectPermanent("/blog");

        ViewData["Title"] = article.Post.Title;
        ViewData["Description"] = article.Post.Excerpt;
        return View(article);
    }

    private async Task<IActionResult> Listing(int page, string? category, int? year, int? month, CancellationToken cancellationToken)
    {
        if (page < 1)
            return NotFound();

        var categorySlug = string.IsNullOrEmpty(category) ? null : BlogUrls.Slugify(category);
        if (category != null && !BlogUrls.IsSlug(categorySlug))
            return NotFound();

        var result = await _blog.PageAsync(page, categorySlug, year, month, cancellationToken);
        if (!result.Known || (page > 1 && page > result.TotalPages))
            return NotFound();

        ViewData["Title"] = result.Heading;
        ViewData["Description"] = result.PageNumber > 1
            ? "Page " + result.PageNumber + " of stories from Wally Wombats."
            : "Stories, party ideas, and play tips from Wally Wombats.";
        ViewData["PrevPath"] = result.PrevPath;
        ViewData["NextPath"] = result.NextPath;
        return View("Index", result);
    }
}
