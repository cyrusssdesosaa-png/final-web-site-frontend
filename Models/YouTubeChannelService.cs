using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace WallyWombatsPublic_MVC.Models;

public class YouTubeChannelService
{
	public const string HandleUrl = "https://www.youtube.com/@wallywombats";
	private const string ChannelId = "UCEIF-wkDkFgnXf2QtGM7nng";
	private const string VideosParams = "EgZ2aWRlb3PyBgQKAjoA";
	private const string ShortsParams = "EgZzaG9ydHPyBgUKA5oBAA==";
	private static readonly TimeSpan CacheFor = TimeSpan.FromHours(1);

	private static readonly SemaphoreSlim Gate = new(1, 1);
	private static YouTubeFeed Cached;
	private static DateTimeOffset CachedAt;
	private readonly HttpClient _http;
	private readonly ILogger<YouTubeChannelService> _logger;

	public YouTubeChannelService(HttpClient http, ILogger<YouTubeChannelService> logger)
	{
		_http = http;
		_logger = logger;
	}

	public async Task<YouTubeFeed> GetAsync(CancellationToken cancellationToken = default, bool force = false)
	{
		if (!force && IsFresh())
		{
			return Cached;
		}

		await Gate.WaitAsync(cancellationToken);
		try
		{
			if (!force && IsFresh())
			{
				return Cached;
			}

			var feed = await LoadAsync(cancellationToken);
			if (feed.Shorts.Count > 0 || feed.Videos.Count > 0)
			{
				Cached = feed;
				CachedAt = DateTimeOffset.UtcNow;
				return feed;
			}

			return Cached ?? feed;
		}
		finally
		{
			Gate.Release();
		}
	}

	private static bool IsFresh() =>
		Cached != null && DateTimeOffset.UtcNow - CachedAt < CacheFor;

	private async Task<YouTubeFeed> LoadAsync(CancellationToken cancellationToken)
	{
		var shortsTask = BrowseAsync(ShortsParams, shorts: true, cancellationToken);
		var videosTask = BrowseAsync(VideosParams, shorts: false, cancellationToken);
		await Task.WhenAll(shortsTask, videosTask);

		var shorts = Dedup(shortsTask.Result);
		var videos = Dedup(videosTask.Result)
			.Where(v => shorts.All(s => !string.Equals(s.Id, v.Id, StringComparison.Ordinal)))
			.ToList();

		if (shorts.Count == 0 && videos.Count == 0)
		{
			return await LoadRssAsync(cancellationToken);
		}

		if (shorts.Count == 0 || videos.Count == 0)
		{
			var rss = await LoadRssAsync(cancellationToken);
			if (shorts.Count == 0) shorts = rss.Shorts.ToList();
			if (videos.Count == 0) videos = rss.Videos.ToList();
		}

		return new YouTubeFeed
		{
			Shorts = shorts.Take(24).ToList(),
			Videos = videos.Take(12).ToList()
		};
	}

	private async Task<List<YouTubeClip>> BrowseAsync(string tabParams, bool shorts, CancellationToken cancellationToken)
	{
		try
		{
			var payload = "{\"context\":{\"client\":{\"clientName\":\"WEB\",\"clientVersion\":\"2.20241001.00.00\"}},\"browseId\":\"" + ChannelId + "\",\"params\":\"" + tabParams + "\"}";
			using var content = new StringContent(payload, Encoding.UTF8, "application/json");
			using var response = await _http.PostAsync("youtubei/v1/browse", content, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				return new List<YouTubeClip>();
			}

			await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
			using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
			var found = new List<YouTubeClip>();
			Walk(doc.RootElement, found, shorts);
			return found;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex, "YouTube browse failed for {Tab}.", shorts ? "shorts" : "videos");
			return new List<YouTubeClip>();
		}
	}

	private static void Walk(JsonElement el, List<YouTubeClip> into, bool shorts)
	{
		if (el.ValueKind == JsonValueKind.Object)
		{
			if (el.TryGetProperty("shortsLockupViewModel", out var shortsLockup) && TryShort(shortsLockup, out var shortClip))
			{
				into.Add(shortClip);
			}
			if (el.TryGetProperty("reelItemRenderer", out var reel) && TryShort(reel, out var reelClip))
			{
				into.Add(reelClip);
			}
			if (!shorts && el.TryGetProperty("videoRenderer", out var video) && TryVideo(video, out var videoClip))
			{
				into.Add(videoClip);
			}
			if (!shorts && el.TryGetProperty("gridVideoRenderer", out var grid) && TryVideo(grid, out var gridClip))
			{
				into.Add(gridClip);
			}
			if (!shorts && el.TryGetProperty("lockupViewModel", out var videoLockup) && TryLockupVideo(videoLockup, out var lockClip))
			{
				into.Add(lockClip);
			}

			foreach (var prop in el.EnumerateObject())
			{
				Walk(prop.Value, into, shorts);
			}
		}
		else if (el.ValueKind == JsonValueKind.Array)
		{
			foreach (var item in el.EnumerateArray())
			{
				Walk(item, into, shorts);
			}
		}
	}

	private static bool TryShort(JsonElement node, out YouTubeClip clip)
	{
		clip = null;
		var id = FindVideoId(node);
		if (string.IsNullOrWhiteSpace(id))
		{
			return false;
		}

		var title = ReadNestedContent(node, "overlayMetadata", "primaryText", "content");
		if (string.IsNullOrWhiteSpace(title) && node.TryGetProperty("accessibilityText", out var access) && access.ValueKind == JsonValueKind.String)
		{
			title = access.GetString() ?? "";
			var cut = title.IndexOf(" , ", StringComparison.Ordinal);
			if (cut > 0) title = title[..cut];
			title = title.Replace(" - play Short", "", StringComparison.OrdinalIgnoreCase).Trim();
		}

		clip = MakeClip(id, title, true);
		return true;
	}

	private static bool TryLockupVideo(JsonElement node, out YouTubeClip clip)
	{
		clip = null;
		if (node.ValueKind != JsonValueKind.Object)
		{
			return false;
		}

		if (!node.TryGetProperty("contentId", out var idEl) || idEl.ValueKind != JsonValueKind.String)
		{
			return false;
		}

		if (node.TryGetProperty("contentType", out var typeEl)
			&& typeEl.ValueKind == JsonValueKind.String
			&& !string.Equals(typeEl.GetString(), "LOCKUP_CONTENT_TYPE_VIDEO", StringComparison.Ordinal))
		{
			return false;
		}

		var title = ReadNestedContent(node, "metadata", "lockupMetadataViewModel", "title", "content");
		if (string.IsNullOrWhiteSpace(title))
		{
			title = FindAccessibilityLabel(node);
		}

		clip = MakeClip(idEl.GetString(), StripDuration(title), false);
		return clip != null && !string.IsNullOrWhiteSpace(clip.Id);
	}

	private static string FindAccessibilityLabel(JsonElement el)
	{
		if (el.ValueKind == JsonValueKind.Object)
		{
			if (el.TryGetProperty("accessibilityContext", out var ctx)
				&& ctx.TryGetProperty("label", out var label)
				&& label.ValueKind == JsonValueKind.String)
			{
				return label.GetString();
			}

			foreach (var prop in el.EnumerateObject())
			{
				var found = FindAccessibilityLabel(prop.Value);
				if (!string.IsNullOrWhiteSpace(found))
				{
					return found;
				}
			}
		}
		else if (el.ValueKind == JsonValueKind.Array)
		{
			foreach (var item in el.EnumerateArray())
			{
				var found = FindAccessibilityLabel(item);
				if (!string.IsNullOrWhiteSpace(found))
				{
					return found;
				}
			}
		}

		return "";
	}

	private static string StripDuration(string title)
	{
		if (string.IsNullOrWhiteSpace(title))
		{
			return title;
		}

		return Regex.Replace(
			title,
			@"\s+\d+\s+(hours?|minutes?|seconds?)(,?\s+\d+\s+(hours?|minutes?|seconds?))*$",
			"",
			RegexOptions.IgnoreCase).Trim();
	}

	private static bool TryVideo(JsonElement node, out YouTubeClip clip)
	{
		clip = null;
		if (!node.TryGetProperty("videoId", out var idEl) || idEl.ValueKind != JsonValueKind.String)
		{
			return false;
		}

		clip = MakeClip(idEl.GetString(), ReadTitle(node), false);
		return clip != null && !string.IsNullOrWhiteSpace(clip.Id);
	}

	private static YouTubeClip MakeClip(string id, string title, bool isShort)
	{
		id = (id ?? "").Trim();
		title = string.IsNullOrWhiteSpace(title) ? "Wally Wombats" : title.Trim();
		return new YouTubeClip
		{
			Id = id,
			Title = title,
			IsShort = isShort,
			Thumbnail = "https://i.ytimg.com/vi/" + id + "/hqdefault.jpg"
		};
	}

	private static string FindVideoId(JsonElement el)
	{
		if (el.ValueKind == JsonValueKind.Object)
		{
			if (el.TryGetProperty("reelWatchEndpoint", out var endpoint)
				&& endpoint.TryGetProperty("videoId", out var idEl)
				&& idEl.ValueKind == JsonValueKind.String)
			{
				return idEl.GetString();
			}

			foreach (var prop in el.EnumerateObject())
			{
				var found = FindVideoId(prop.Value);
				if (!string.IsNullOrWhiteSpace(found))
				{
					return found;
				}
			}
		}
		else if (el.ValueKind == JsonValueKind.Array)
		{
			foreach (var item in el.EnumerateArray())
			{
				var found = FindVideoId(item);
				if (!string.IsNullOrWhiteSpace(found))
				{
					return found;
				}
			}
		}

		return null;
	}

	private static string ReadTitle(JsonElement node)
	{
		if (!node.TryGetProperty("title", out var title))
		{
			if (node.TryGetProperty("headline", out var headline))
			{
				title = headline;
			}
			else
			{
				return "";
			}
		}

		if (title.TryGetProperty("simpleText", out var simple) && simple.ValueKind == JsonValueKind.String)
		{
			return simple.GetString();
		}

		if (title.TryGetProperty("runs", out var runs) && runs.ValueKind == JsonValueKind.Array && runs.GetArrayLength() > 0)
		{
			var first = runs[0];
			if (first.TryGetProperty("text", out var text) && text.ValueKind == JsonValueKind.String)
			{
				return text.GetString();
			}
		}

		if (title.TryGetProperty("content", out var content) && content.ValueKind == JsonValueKind.String)
		{
			return content.GetString();
		}

		return "";
	}

	private static string ReadNestedContent(JsonElement node, params string[] path)
	{
		var current = node;
		foreach (var key in path)
		{
			if (current.ValueKind != JsonValueKind.Object || !current.TryGetProperty(key, out current))
			{
				return "";
			}
		}

		return current.ValueKind == JsonValueKind.String ? current.GetString() : "";
	}

	private async Task<YouTubeFeed> LoadRssAsync(CancellationToken cancellationToken)
	{
		var feed = new YouTubeFeed();
		try
		{
			using var response = await _http.GetAsync("feeds/videos.xml?channel_id=" + ChannelId, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				return feed;
			}

			var xml = await response.Content.ReadAsStringAsync(cancellationToken);
			var doc = XDocument.Parse(xml);
			XNamespace atom = "http://www.w3.org/2005/Atom";
			XNamespace yt = "http://www.youtube.com/xml/schemas/2015";
			foreach (var entry in doc.Root?.Elements(atom + "entry") ?? Enumerable.Empty<XElement>())
			{
				var id = entry.Element(yt + "videoId")?.Value;
				if (string.IsNullOrWhiteSpace(id))
				{
					continue;
				}

				var href = entry.Element(atom + "link")?.Attribute("href")?.Value ?? "";
				var isShort = href.Contains("/shorts/", StringComparison.OrdinalIgnoreCase);
				var clip = MakeClip(id, entry.Element(atom + "title")?.Value, isShort);
				if (isShort) feed.Shorts.Add(clip);
				else feed.Videos.Add(clip);
			}
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex, "YouTube RSS fallback failed.");
		}

		return feed;
	}

	private static List<YouTubeClip> Dedup(IEnumerable<YouTubeClip> clips)
	{
		var seen = new HashSet<string>(StringComparer.Ordinal);
		var list = new List<YouTubeClip>();
		foreach (var clip in clips)
		{
			if (clip == null || string.IsNullOrWhiteSpace(clip.Id) || !seen.Add(clip.Id))
			{
				continue;
			}

			list.Add(clip);
		}

		return list;
	}
}
