using System.Globalization;
using System.Text.Json;

namespace WallyWombatsPublic_MVC.Models;

public sealed record SoroArticle(
    string Id,
    string Title,
    string Slug,
    string Excerpt,
    string? ImageUrl,
    DateTimeOffset Published);

/// <summary>
/// Reads the public Soro embed script. Article bodies are not in that script;
/// they are loaded separately and are never rewritten here.
/// </summary>
public static class SoroBlogParser
{
    public const string Marker = "var SORO_ARTICLES = ";

    public static IReadOnlyList<SoroArticle> Parse(string? script)
    {
        if (string.IsNullOrEmpty(script))
            return Array.Empty<SoroArticle>();

        var at = script.IndexOf(Marker, StringComparison.Ordinal);
        if (at < 0)
            return Array.Empty<SoroArticle>();

        var json = ReadJsonArray(script, at + Marker.Length);
        if (json == null)
            return Array.Empty<SoroArticle>();

        JsonDocument doc;
        try
        {
            doc = JsonDocument.Parse(json);
        }
        catch (JsonException)
        {
            return Array.Empty<SoroArticle>();
        }

        using (doc)
        {
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
                return Array.Empty<SoroArticle>();

            var list = new List<SoroArticle>();
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                var title = Text(item, "title");
                var slug = BlogUrls.Slugify(Text(item, "slug"));
                var id = Text(item, "id");
                if (title.Length == 0 || slug.Length == 0 || id.Length == 0)
                    continue;

                DateTimeOffset published = DateTimeOffset.UnixEpoch;
                var iso = Text(item, "isoDate");
                if (DateTimeOffset.TryParse(iso, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var parsed))
                    published = parsed;

                list.Add(new SoroArticle(
                    id,
                    title,
                    slug,
                    Text(item, "excerpt"),
                    BlogHtml.SafeImage(Text(item, "image")),
                    published));
            }

            return list;
        }
    }

    private static string Text(JsonElement item, string name)
    {
        if (!item.TryGetProperty(name, out var value) || value.ValueKind != JsonValueKind.String)
            return "";
        return (value.GetString() ?? "").Trim();
    }

    internal static string? ReadJsonArray(string script, int start)
    {
        while (start < script.Length && char.IsWhiteSpace(script[start]))
            start++;
        if (start >= script.Length || script[start] != '[')
            return null;

        var depth = 0;
        var inString = false;
        var escaped = false;
        for (var i = start; i < script.Length; i++)
        {
            var c = script[i];
            if (inString)
            {
                if (escaped)
                    escaped = false;
                else if (c == '\\')
                    escaped = true;
                else if (c == '"')
                    inString = false;
                continue;
            }

            if (c == '"')
                inString = true;
            else if (c == '[')
                depth++;
            else if (c == ']')
            {
                depth--;
                if (depth == 0)
                    return script.Substring(start, i - start + 1);
            }
        }

        return null;
    }
}
