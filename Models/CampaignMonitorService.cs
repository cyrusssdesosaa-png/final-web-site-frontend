using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WallyWombatsPublic_MVC.Models;

public class CampaignMonitorService
{
	private readonly HttpClient _httpClient;

	public CampaignMonitorService()
	{
		_httpClient = new HttpClient();
	}

	public async Task AddSubscriberAsync(string email, string firstname, string lastname)
	{
		string url = "https://api.createsend.com/api/v3.3/subscribers/2173ea4b426286a5f28f6f8a8a2e0f80.json";
		var requestBody = new
		{
			EmailAddress = email,
			Name = firstname + " " + lastname,
			Resubscribe = true,
			ConsentToTrack = "Yes"
		};
		string json = JsonSerializer.Serialize(requestBody);
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		HttpResponseMessage response = await _httpClient.PostAsync(url, content);
		if (response.IsSuccessStatusCode)
		{
			Console.WriteLine("Subscriber added successfully!");
			return;
		}
		string errorContent = await response.Content.ReadAsStringAsync();
		Console.WriteLine($"Error: {response.StatusCode} - {errorContent}");
	}
}
