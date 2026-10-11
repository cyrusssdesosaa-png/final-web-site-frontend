using System.Collections.Generic;

namespace WallyWombatsPublic_MVC.Models;

public class YouTubeClip
{
	public string Id { get; set; }

	public string Title { get; set; }

	public string Thumbnail { get; set; }

	public bool IsShort { get; set; }

	public string WatchUrl => IsShort
		? "https://www.youtube.com/shorts/" + Id
		: "https://www.youtube.com/watch?v=" + Id;
}

public class YouTubeFeed
{
	public IList<YouTubeClip> Shorts { get; set; } = new List<YouTubeClip>();

	public IList<YouTubeClip> Videos { get; set; } = new List<YouTubeClip>();
}
