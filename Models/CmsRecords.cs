namespace WallyWombatsPublic_MVC.Models;

public class SocialCard
{
    public int Id { get; set; }

    public string Platform { get; set; } = "";

    public string Title { get; set; } = "";

    public string? Url { get; set; }

    public string? Thumbnail { get; set; }

    public string? YouTubeId { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; } = true;
}

public class Subscriber
{
    public int Id { get; set; }

    public string Email { get; set; } = "";

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime DateCreated { get; set; }
}

public class SiteSetting
{
    public int Id { get; set; }

    public string SettingKey { get; set; } = "";

    public string? SettingValue { get; set; }
}

public class Friend
{
    public int Id { get; set; }

    public string Slug { get; set; } = "";

    public string Name { get; set; } = "";

    public string? ShortName { get; set; }

    public string? Tagline { get; set; }

    public string? Headline { get; set; }

    public string? Greeting { get; set; }

    public string? Intro { get; set; }

    public string? Story { get; set; }

    public string? Image { get; set; }

    public string? FactsText { get; set; }

    public string? LovesText { get; set; }

    public string? DidYouKnow { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public CharacterProfile ToProfile() => new()
    {
        Slug = Slug,
        Name = Name,
        ShortName = string.IsNullOrWhiteSpace(ShortName) ? Name : ShortName,
        Tagline = Tagline ?? "",
        Headline = Headline ?? "",
        Greeting = Greeting ?? "",
        Intro = Intro ?? "",
        Story = Story ?? "",
        Image = string.IsNullOrWhiteSpace(Image) ? "~/img/theme/characters/stand-wally.png" : Image,
        DidYouKnow = DidYouKnow ?? "",
        Facts = ParseFacts(FactsText),
        Loves = (LovesText ?? "")
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .ToList()
    };

    public static string FormatFacts(IEnumerable<KeyValuePair<string, string>> facts) =>
        string.Join("\n", facts.Select(pair => pair.Key + ": " + pair.Value));

    public static string FormatLoves(IEnumerable<string> loves) => string.Join("\n", loves);

    private static Dictionary<string, string> ParseFacts(string? text)
    {
        var facts = new Dictionary<string, string>();
        foreach (var line in (text ?? "").Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var split = line.IndexOf(':');
            if (split <= 0) continue;
            facts[line[..split].Trim()] = line[(split + 1)..].Trim();
        }
        return facts;
    }
}

public class Users
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }

    public string? ProfilePicture { get; set; }

    public bool IsActive { get; set; }

    public DateTime DateCreated { get; set; }
}
