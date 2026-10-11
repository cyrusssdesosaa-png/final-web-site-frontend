using Microsoft.EntityFrameworkCore;

namespace WallyWombatsPublic_MVC.Models;

public class SiteContent
{
    private readonly Dictionary<string, string> _settings;
    private readonly IReadOnlyList<SocialCard> _cards;
    private readonly IReadOnlyList<Friend> _friends;

    public SiteContent(WWContext db)
    {
        try
        {
            _settings = db.SiteSettings.AsNoTracking()
                .ToDictionary(s => s.SettingKey, s => s.SettingValue ?? "", StringComparer.OrdinalIgnoreCase);
            _cards = db.SocialCards.AsNoTracking()
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ThenBy(c => c.Id)
                .ToList();
            _friends = db.Friends.AsNoTracking().OrderBy(f => f.SortOrder).ToList();
        }
        catch
        {
            _settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            _cards = Array.Empty<SocialCard>();
            _friends = Array.Empty<Friend>();
        }
    }

    public string Text(string key, string fallback)
    {
        if (_settings.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value))
            return value;
        return fallback;
    }

    public IReadOnlyList<SocialCard> For(string platform) =>
        _cards.Where(c => string.Equals(c.Platform, platform, StringComparison.OrdinalIgnoreCase)).ToList();

    public IReadOnlyList<CharacterProfile> Friends()
    {
        var rows = _friends.Where(f => f.IsActive).Select(f => f.ToProfile()).ToList();
        return rows.Count > 0 ? rows : CharacterCatalog.All.ToList();
    }

    public IReadOnlyList<SocialCard> Or(string platform, IEnumerable<SocialPost> fallback)
    {
        var rows = For(platform);
        if (rows.Count > 0) return rows;
        return fallback.Select((post, index) => new SocialCard
        {
            Platform = platform,
            Title = post.Title,
            Url = post.Url,
            Thumbnail = post.Thumbnail,
            YouTubeId = post.YouTubeId,
            SortOrder = index,
            IsActive = true
        }).ToList();
    }
}
