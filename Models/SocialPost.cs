using System.Collections.Generic;

namespace WallyWombatsPublic_MVC.Models;

public class SocialPost
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Thumbnail { get; set; }
    public string YouTubeId { get; set; }
}

public static class InstagramPosts
{
    public static IReadOnlyList<SocialPost> Latest { get; } = new List<SocialPost>
    {
        new() { Title = "Playground reels from Rainbow", Url = SocialLinks.InstagramReels, Thumbnail = "/img/locations/las-vegas/01.jpg" },
        new() { Title = "Henderson play day clips", Url = SocialLinks.InstagramReels, Thumbnail = "/img/locations/henderson/01.jpg" },
        new() { Title = "Bullhead City adventures", Url = SocialLinks.InstagramReels, Thumbnail = "/img/locations/bullhead-city/01.jpg" },
        new() { Title = "More Wally reels on Instagram", Url = SocialLinks.Instagram, Thumbnail = "/img/locations/las-vegas/02.jpg" }
    };
}

public static class TikTokPosts
{
    public static IReadOnlyList<SocialPost> Latest { get; } = new List<SocialPost>
    {
        new() { Title = "Move. Play. Explore. on TikTok", Url = SocialLinks.TikTok, Thumbnail = "/img/locations/henderson/02.jpg" },
        new() { Title = "Wally clips for little explorers", Url = SocialLinks.TikTok, Thumbnail = "/img/locations/bullhead-city/02.jpg" },
        new() { Title = "Playground moments from the clubs", Url = SocialLinks.TikTok, Thumbnail = "/img/locations/las-vegas/03.jpg" },
        new() { Title = "Watch more on TikTok", Url = SocialLinks.TikTok, Thumbnail = "/img/locations/henderson/03.jpg" }
    };
}

public static class FacebookPosts
{
    public static IReadOnlyList<SocialPost> Latest { get; } = new List<SocialPost>
    {
        new()
        {
            Title = "Wally's story is officially here. Episode 1 is playing now.",
            Url = SocialLinks.Facebook,
            Thumbnail = "https://i.ytimg.com/vi/ecI3QG8U87k/hqdefault.jpg",
            YouTubeId = "ecI3QG8U87k"
        },
        new()
        {
            Title = "WAIT. Wally was this tiny? Baby wombat in Mama's pouch.",
            Url = SocialLinks.Facebook,
            Thumbnail = "https://i.ytimg.com/vi/ecI3QG8U87k/mqdefault.jpg"
        },
        new()
        {
            Title = "Okay, we've met Wally. But what exactly is a wombat?",
            Url = SocialLinks.Facebook,
            Thumbnail = "/img/locations/las-vegas/01.jpg"
        },
        new()
        {
            Title = "Bullhead City grand opening. October 15. Come join us.",
            Url = SocialLinks.Facebook,
            Thumbnail = "/img/locations/bullhead-city/01.jpg"
        },
        new()
        {
            Title = "He's almost here. Curious, playful, and ready to explore.",
            Url = SocialLinks.Facebook,
            Thumbnail = "/img/AOP/ww-004.jpg"
        },
        new()
        {
            Title = "Wait. Someone was here. Today we found our first clue.",
            Url = SocialLinks.Facebook,
            Thumbnail = "/img/locations/henderson/01.jpg"
        }
    };
}
