using Microsoft.EntityFrameworkCore;

namespace WallyWombatsPublic_MVC.Models;

public static class CmsSchema
{
    public static void Ensure(WWContext db, IConfiguration config)
    {
        if (db.Database.IsRelational())
        {
            db.Database.ExecuteSqlRaw(CreateSql);
        }

        Seed(db, config);
    }

    private static void Seed(WWContext db, IConfiguration config)
    {
        if (!db.Location.Any())
            DemoSeed.Ensure(db);

        if (!db.SocialCards.Any())
        {
            AddCards(db, "instagram", InstagramPosts.Latest);
            AddCards(db, "tiktok", TikTokPosts.Latest);
            AddCards(db, "facebook", FacebookPosts.Latest);
            db.SaveChanges();
        }

        var knownKeys = db.SiteSettings.Select(s => s.SettingKey).ToList();
        var missing = Defaults.Where(pair => !knownKeys.Contains(pair.Key, StringComparer.OrdinalIgnoreCase)).ToList();
        if (missing.Count > 0)
        {
            foreach (var pair in missing)
                db.SiteSettings.Add(new SiteSetting { SettingKey = pair.Key, SettingValue = pair.Value });
            db.SaveChanges();
        }

        if (!db.Friends.Any())
        {
            var order = 0;
            foreach (var pal in CharacterCatalog.All)
            {
                db.Friends.Add(new Friend
                {
                    Slug = pal.Slug,
                    Name = pal.Name,
                    ShortName = pal.ShortName,
                    Tagline = pal.Tagline,
                    Headline = pal.Headline,
                    Greeting = pal.Greeting,
                    Intro = pal.Intro,
                    Story = pal.Story,
                    Image = pal.Image,
                    FactsText = Friend.FormatFacts(pal.Facts),
                    LovesText = Friend.FormatLoves(pal.Loves),
                    DidYouKnow = pal.DidYouKnow,
                    SortOrder = order++,
                    IsActive = true
                });
            }
            db.SaveChanges();
        }

        foreach (var loc in db.Location.Where(l => l.Latitude == null || l.Longitude == null).ToList())
        {
            var pin = LocationMapPins.Coords(loc.Slug);
            if (pin == null) continue;
            loc.Latitude = pin.Value.Lat;
            loc.Longitude = pin.Value.Lng;
        }
        db.SaveChanges();

        var seedPassword = config["AdminSeedPassword"];
        if (!string.IsNullOrWhiteSpace(seedPassword) && !db.Users.Any())
        {
            db.Users.Add(new Users
            {
                FirstName = "Wally",
                LastName = "Admin",
                UserName = "admin",
                EmailAddress = "info@wallywombats.com",
                Password = seedPassword,
                IsActive = true,
                DateCreated = DateTime.UtcNow
            });
            db.SaveChanges();
        }
    }

    private static void AddCards(WWContext db, string platform, IReadOnlyList<SocialPost> posts)
    {
        var order = 0;
        foreach (var post in posts)
        {
            db.SocialCards.Add(new SocialCard
            {
                Platform = platform,
                Title = post.Title ?? "",
                Url = post.Url,
                Thumbnail = post.Thumbnail,
                YouTubeId = string.IsNullOrWhiteSpace(post.YouTubeId) ? null : post.YouTubeId,
                SortOrder = order++,
                IsActive = true
            });
        }
    }

    private static readonly Dictionary<string, string> Defaults = new()
    {
        ["home.hero.lead"] = "Big fun for",
        ["home.hero.accent"] = "little adventurers!",
        ["watch.kicker"] = "Meet Wally and the Super Friends",
        ["watch.title.lead"] = "Come join",
        ["watch.title.accent"] = "the fun!",
        ["watch.blurb"] = "Watch Wally and his friends in a playful adventure made for little explorers.",
        ["crew.kicker"] = "Meet Wally and Friends",
        ["crew.title.lead"] = "Every adventure is",
        ["crew.title.accent"] = "better with friends.",
        ["crew.blurb"] = "Tap a Super Friend to read their story, favorite things, and fun facts.",
        ["playground.kicker"] = "Our playground",
        ["playground.title.lead"] = "Room to climb.",
        ["playground.title.accent"] = "Space to imagine.",
        ["playground.blurb"] = "Slides, tunnels, ball pits, obstacle zones, and open spaces give every child a new way to move, explore, and grow.",
        ["arcade.kicker"] = "Level up the fun",
        ["arcade.title.lead"] = "Bright lights.",
        ["arcade.title.accent"] = "Big wins.",
        ["arcade.blurb"] = "Racing games, prize machines, air hockey, and arcade favorites keep kids and grown-ups coming back for one more round.",
        ["birthdays.kicker"] = "Birthdays at Wally's",
        ["birthdays.title.lead"] = "Their biggest day.",
        ["birthdays.title.accent"] = "Your easiest party.",
        ["birthdays.blurb"] = "Private party rooms, all-day play, and a celebration made for little adventurers. Pick a location to see packages and prices.",
        ["notes.kicker"] = "Loved by Las Vegas parents",
        ["notes.title"] = "Notes from Wally families",
        ["faq.kicker"] = "Good to know",
        ["faq.title.lead"] = "Before your",
        ["faq.title.accent"] = "Wally day.",
        ["faq.blurb"] = "Quick answers for a smoother family adventure.",
        ["contact.kicker"] = "Send Wally a note",
        ["contact.title.lead"] = "Do you have",
        ["contact.title.accent"] = "a question?",
        ["contact.blurb"] = "Give us a call or send a message. The Wally team is always eager to hear from friends.",
        ["footer.tagline"] = "Big adventures for little explorers and better family days for everyone.",
        ["follow.youtube"] = SocialLinks.YouTube,
        ["follow.facebook"] = SocialLinks.Facebook,
        ["follow.instagram"] = SocialLinks.Instagram,
        ["follow.tiktok"] = SocialLinks.TikTok,
        ["follow.spotify"] = SocialLinks.Spotify,
        ["ribbon.text"] = "Three locations • Open seven days a week",
        ["spotify.kicker"] = "Listen with Wally",
        ["spotify.title.lead"] = "Wally on",
        ["spotify.title.accent"] = "Spotify",
        ["spotify.blurb"] = "Songs, stories, and sing-alongs from Wally Wombats. Press play here, or open it in Spotify.",
        ["spotify.embed"] = "https://open.spotify.com/embed/artist/0Af4H36JSiCOv5ljeuPg0S?utm_source=generator"
    };

    public static void ImportClips(WWContext db, string platform, IEnumerable<YouTubeClip> clips)
    {
        var fresh = clips.Where(c => !string.IsNullOrWhiteSpace(c.Id)).Take(6).ToList();
        if (fresh.Count == 0) return;
        var old = db.SocialCards.Where(c => c.Platform == platform).ToList();
        if (old.Count > 0) db.SocialCards.RemoveRange(old);
        var order = 0;
        foreach (var clip in fresh)
        {
            db.SocialCards.Add(new SocialCard
            {
                Platform = platform,
                Title = clip.Title ?? "Wally video",
                Url = clip.WatchUrl,
                Thumbnail = clip.Thumbnail,
                YouTubeId = clip.Id,
                SortOrder = order++,
                IsActive = true
            });
        }
        db.SaveChanges();
    }

    public static void RefreshYouTube(WWContext db, YouTubeFeed feed)
    {
        if (feed == null) return;
        if ((feed.Shorts == null || feed.Shorts.Count == 0) && (feed.Videos == null || feed.Videos.Count == 0)) return;

        var stamp = db.SiteSettings.FirstOrDefault(s => s.SettingKey == "socials.refreshed");
        if (stamp != null
            && DateTime.TryParse(stamp.SettingValue, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out var at)
            && DateTime.UtcNow - at < TimeSpan.FromHours(1))
            return;

        ImportClips(db, "youtube-shorts", feed.Shorts ?? new List<YouTubeClip>());
        ImportClips(db, "youtube-series", feed.Videos ?? new List<YouTubeClip>());
        var now = DateTime.UtcNow.ToString("o");
        if (stamp == null)
            db.SiteSettings.Add(new SiteSetting { SettingKey = "socials.refreshed", SettingValue = now });
        else
            stamp.SettingValue = now;
        db.SaveChanges();
    }

    private const string CreateSql = @"
IF OBJECT_ID(N'Location', N'U') IS NULL
CREATE TABLE Location (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Slug nvarchar(50) NOT NULL,
  Name nvarchar(100) NOT NULL,
  Address nvarchar(300) NULL,
  Phone nvarchar(30) NULL,
  Email nvarchar(100) NULL,
  HoursMonFri nvarchar(50) NULL,
  HoursSatSun nvarchar(50) NULL,
  WaiverUrl nvarchar(500) NULL,
  TicketsUrl nvarchar(500) NULL,
  YoutubeUrl nvarchar(500) NULL,
  HeroImageUrl nvarchar(500) NULL,
  MapEmbedUrl nvarchar(1000) NULL,
  IsActive bit NOT NULL CONSTRAINT DF_Location_IsActive DEFAULT 1,
  SortOrder int NOT NULL CONSTRAINT DF_Location_SortOrder DEFAULT 0,
  ShowPromo bit NOT NULL CONSTRAINT DF_Location_ShowPromo DEFAULT 0,
  PromoHeadline nvarchar(200) NULL,
  PromoBody nvarchar(2000) NULL
);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Location_Slug' AND object_id = OBJECT_ID(N'Location'))
CREATE UNIQUE INDEX IX_Location_Slug ON Location(Slug);

IF OBJECT_ID(N'GeneralAdmission', N'U') IS NULL
CREATE TABLE GeneralAdmission (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  GAGroup nvarchar(max) NULL,
  GAName nvarchar(max) NULL,
  GAPrice decimal(10,2) NOT NULL,
  GACategory nvarchar(max) NULL,
  GAInclusion nvarchar(max) NULL,
  LocationId int NULL
);

IF OBJECT_ID(N'PartyPackage', N'U') IS NULL
CREATE TABLE PartyPackage (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  PackageCategory nvarchar(max) NULL,
  PackageImage nvarchar(max) NULL,
  PackageName nvarchar(max) NULL,
  PackagePrice decimal(10,2) NOT NULL,
  PackageDescription nvarchar(max) NULL,
  LocationId int NULL
);

IF OBJECT_ID(N'Testimonial', N'U') IS NULL
CREATE TABLE Testimonial (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Comments nvarchar(max) NULL,
  CommentBy nvarchar(max) NULL,
  CommentByPicture nvarchar(max) NULL,
  DateCreated datetime2 NOT NULL
);

IF OBJECT_ID(N'FAQ', N'U') IS NULL
CREATE TABLE FAQ (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Category nvarchar(max) NULL,
  Question nvarchar(max) NULL,
  Answer nvarchar(max) NULL
);

IF OBJECT_ID(N'Blog', N'U') IS NULL
CREATE TABLE Blog (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  DateCreated datetime2 NOT NULL,
  Title nvarchar(max) NULL,
  Slug nvarchar(max) NULL,
  Summary nvarchar(max) NULL,
  Description nvarchar(max) NULL,
  AuthorName nvarchar(max) NULL,
  CategoryName nvarchar(max) NULL,
  FeaturedImage nvarchar(max) NULL,
  IsFeaturedPost bit NOT NULL CONSTRAINT DF_Blog_Featured DEFAULT 0,
  IsPublished bit NOT NULL CONSTRAINT DF_Blog_Published DEFAULT 0
);

IF OBJECT_ID(N'CalendarEvents', N'U') IS NULL
CREATE TABLE CalendarEvents (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  EventDate datetime2 NOT NULL,
  EventTimeStart nvarchar(max) NULL,
  EventTimeEnd nvarchar(max) NULL,
  EventDetails nvarchar(max) NULL,
  EventTitle nvarchar(max) NULL,
  EventPlace nvarchar(max) NULL,
  EventLocation nvarchar(max) NULL
);

IF OBJECT_ID(N'Users', N'U') IS NULL
CREATE TABLE Users (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  FirstName nvarchar(max) NULL,
  LastName nvarchar(max) NULL,
  UserName nvarchar(max) NULL,
  EmailAddress nvarchar(max) NULL,
  Password nvarchar(max) NULL,
  ProfilePicture nvarchar(max) NULL,
  IsActive bit NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT 1,
  DateCreated datetime2 NOT NULL
);

IF OBJECT_ID(N'SocialCards', N'U') IS NULL
CREATE TABLE SocialCards (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Platform nvarchar(40) NOT NULL,
  Title nvarchar(300) NOT NULL,
  Url nvarchar(500) NULL,
  Thumbnail nvarchar(500) NULL,
  YouTubeId nvarchar(40) NULL,
  SortOrder int NOT NULL CONSTRAINT DF_SocialCards_Sort DEFAULT 0,
  IsActive bit NOT NULL CONSTRAINT DF_SocialCards_Active DEFAULT 1
);

IF OBJECT_ID(N'SiteSettings', N'U') IS NULL
CREATE TABLE SiteSettings (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  SettingKey nvarchar(80) NOT NULL,
  SettingValue nvarchar(2000) NULL
);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_SiteSettings_SettingKey' AND object_id = OBJECT_ID(N'SiteSettings'))
CREATE UNIQUE INDEX IX_SiteSettings_SettingKey ON SiteSettings(SettingKey);

IF COL_LENGTH(N'Location', N'Latitude') IS NULL ALTER TABLE Location ADD Latitude float NULL;
IF COL_LENGTH(N'Location', N'Longitude') IS NULL ALTER TABLE Location ADD Longitude float NULL;

IF OBJECT_ID(N'Friends', N'U') IS NULL
CREATE TABLE Friends (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Slug nvarchar(40) NOT NULL,
  Name nvarchar(120) NOT NULL,
  ShortName nvarchar(80) NULL,
  Tagline nvarchar(300) NULL,
  Headline nvarchar(300) NULL,
  Greeting nvarchar(300) NULL,
  Intro nvarchar(2000) NULL,
  Story nvarchar(max) NULL,
  Image nvarchar(300) NULL,
  FactsText nvarchar(max) NULL,
  LovesText nvarchar(max) NULL,
  DidYouKnow nvarchar(2000) NULL,
  SortOrder int NOT NULL CONSTRAINT DF_Friends_Sort DEFAULT 0,
  IsActive bit NOT NULL CONSTRAINT DF_Friends_Active DEFAULT 1
);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Friends_Slug' AND object_id = OBJECT_ID(N'Friends'))
CREATE UNIQUE INDEX IX_Friends_Slug ON Friends(Slug);

IF OBJECT_ID(N'Subscribers', N'U') IS NULL
CREATE TABLE Subscribers (
  Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Email nvarchar(200) NOT NULL,
  FirstName nvarchar(120) NULL,
  LastName nvarchar(120) NULL,
  DateCreated datetime2 NOT NULL
);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Subscribers_Email' AND object_id = OBJECT_ID(N'Subscribers'))
CREATE UNIQUE INDEX IX_Subscribers_Email ON Subscribers(Email);
";
}
