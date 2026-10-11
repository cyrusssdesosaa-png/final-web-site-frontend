namespace WallyWombatsPublic_MVC.Models;

public class SocialRefreshService : BackgroundService
{
    private readonly IServiceScopeFactory _scopes;
    private readonly ILogger<SocialRefreshService> _logger;

    public SocialRefreshService(IServiceScopeFactory scopes, ILogger<SocialRefreshService> logger)
    {
        _scopes = scopes;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }

            try
            {
                using var scope = _scopes.CreateScope();
                var youtube = scope.ServiceProvider.GetRequiredService<YouTubeChannelService>();
                var db = scope.ServiceProvider.GetRequiredService<WWContext>();
                var feed = await youtube.GetAsync(stoppingToken, force: true);
                CmsSchema.RefreshYouTube(db, feed);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _logger.LogWarning(ex, "Automatic YouTube refresh did not finish.");
            }
        }
    }
}
