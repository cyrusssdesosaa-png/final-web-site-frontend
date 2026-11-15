using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace WallyWombatsPublic_MVC.Models;

public sealed class SoroBlogClient
{
    public const string EmbedToken = "dfaf496a-5d9e-425c-a7ad-5daef7ed7a7a";

    private const string FreshKey = "soro-articles";
    private const string StaleKey = "soro-articles-stale";

    private readonly HttpClient _http;
    private readonly IMemoryCache _cache;
    private readonly ILogger<SoroBlogClient> _logger;

    public SoroBlogClient(HttpClient http, IMemoryCache cache, ILogger<SoroBlogClient> logger)
    {
        _http = http;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IReadOnlyList<SoroArticle>> GetArticlesAsync(CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue(FreshKey, out IReadOnlyList<SoroArticle>? fresh) && fresh != null)
            return fresh;

        try
        {
            var script = await _http.GetStringAsync("api/embed/" + EmbedToken, cancellationToken);
            var articles = SoroBlogParser.Parse(script);
            _cache.Set(FreshKey, articles, TimeSpan.FromMinutes(20));
            _cache.Set(StaleKey, articles, TimeSpan.FromHours(12));
            return articles;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _logger.LogWarning(ex, "Soro article list could not be refreshed.");
            if (_cache.TryGetValue(StaleKey, out IReadOnlyList<SoroArticle>? stale) && stale != null)
                return stale;
            return Array.Empty<SoroArticle>();
        }
    }

    public async Task<string?> GetArticleHtmlAsync(string? articleId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(articleId))
            return null;

        var key = "soro-body:" + articleId;
        if (_cache.TryGetValue(key, out string? html))
            return html;

        var miss = "soro-body-miss:" + articleId;
        if (_cache.TryGetValue(miss, out _))
            return null;

        try
        {
            var json = await _http.GetStringAsync("api/embed/" + EmbedToken + "/article/" + Uri.EscapeDataString(articleId), cancellationToken);
            using var doc = JsonDocument.Parse(json);
            html = doc.RootElement.TryGetProperty("content", out var content) && content.ValueKind == JsonValueKind.String
                ? content.GetString()
                : null;
            if (string.IsNullOrWhiteSpace(html))
            {
                _cache.Set(miss, true, TimeSpan.FromMinutes(2));
                return null;
            }

            _cache.Set(key, html, TimeSpan.FromHours(6));
            return html;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _logger.LogWarning(ex, "Soro article {ArticleId} could not be loaded.", articleId);
            _cache.Set(miss, true, TimeSpan.FromMinutes(2));
            return null;
        }
    }
}
