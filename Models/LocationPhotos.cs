namespace WallyWombatsPublic_MVC.Models;

public static class LocationPhotos
{
    public static IReadOnlyList<string> For(Location? loc)
    {
        var slug = (loc?.Slug ?? "").Trim().ToLowerInvariant();
        if (slug.Length == 0) return Array.Empty<string>();

        var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "locations", slug);
        if (!Directory.Exists(dir)) return Array.Empty<string>();

        return Directory.GetFiles(dir)
            .Where(f => !string.Equals(Path.GetFileName(f), "card.jpg", StringComparison.OrdinalIgnoreCase))
            .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                || f.EndsWith(".webp", StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => Path.GetFileName(f), StringComparer.OrdinalIgnoreCase)
            .Select(f => "/img/locations/" + slug + "/" + Path.GetFileName(f))
            .ToList();
    }

    public static IReadOnlyList<string> Theme(string folder, string prefix)
    {
        var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "theme", folder);
        if (!Directory.Exists(dir)) return Array.Empty<string>();
        return Directory.GetFiles(dir)
            .Where(f => Path.GetFileName(f).StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                || f.EndsWith(".webp", StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => Path.GetFileName(f), StringComparer.OrdinalIgnoreCase)
            .Select(f => "/img/theme/" + folder + "/" + Path.GetFileName(f))
            .ToList();
    }

    public static string CardImage(Location? loc)
    {
        var slug = (loc?.Slug ?? "").Trim().ToLowerInvariant();
        if (slug.Length > 0)
        {
            var card = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "locations", slug, "card.jpg");
            if (File.Exists(card)) return "/img/locations/" + slug + "/card.jpg";
        }
        var photos = For(loc);
        if (photos.Count > 0) return photos[0];
        var hero = (loc?.HeroImageUrl ?? "").Trim();
        if (hero.Length > 0) return hero;
        return "/img/AOP/ww-004.jpg";
    }
}
