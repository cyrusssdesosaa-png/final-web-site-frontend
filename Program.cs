using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using WallyWombatsPublic_MVC.Models;
using WallyWombatsPublic_MVC.Seo;

var builder = WebApplication.CreateBuilder(args);

// SMTP settings now live in appsettings.json / appsettings.Production.json
// (used to be hardcoded in Program.cs — moved out for secret hygiene).
// Services bind to this configuration via IConfiguration.
builder.Services
    .AddControllersWithViews()
    .ConfigureApplicationPartManager(apm =>
    {
        // Precompiled Razor views (recovered from ILSpy decompile) live in this
        // assembly. Register it explicitly so the ViewsFeatureProvider picks up the
        // [assembly: RazorCompiledItem] attrs emitted by Properties/RazorAssemblyInfo.generated.cs.
        var selfAsm = typeof(Program).Assembly;
        if (!apm.ApplicationParts.OfType<AssemblyPart>().Any(p => p.Assembly == selfAsm))
            apm.ApplicationParts.Add(new AssemblyPart(selfAsm));
    });

var useDemo = DemoSeed.ShouldUseDemo(builder.Configuration, "WWDbConnectionString");
if (useDemo)
{
    builder.Services.AddDbContext<WWContext>(options => options.UseInMemoryDatabase("WallyPublicDemo"));
}
else
{
    builder.Services.AddDbContext<WWContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("WWDbConnectionString")
            ?? throw new InvalidOperationException("Connection string 'WWDbConnectionString' not found.")));
}

builder.Services.AddScoped<SiteContent>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 20_000_000;
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 20_000_000;
});

builder.Services.Configure<SiteOptions>(builder.Configuration.GetSection("Site"));
builder.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<SiteOptions>>().Value;
    return new SeoRedirector(options.OfficialOrigin);
});
builder.Services.AddSingleton<SeoLinkBuilder>();

builder.Services.AddSingleton<EmailService>();
builder.Services.AddHostedService<SocialRefreshService>();
builder.Services.AddHttpClient<YouTubeChannelService>(client =>
{
    client.BaseAddress = new Uri("https://www.youtube.com/");
    client.Timeout = TimeSpan.FromSeconds(8);
    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; WallyWombatsSite/1.0)");
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WWContext>();
    CmsSchema.Ensure(db, app.Configuration);
    try
    {
        var youtube = scope.ServiceProvider.GetRequiredService<YouTubeChannelService>();
        var feed = youtube.GetAsync().GetAwaiter().GetResult();
        CmsSchema.RefreshYouTube(db, feed);
    }
    catch (Exception ex)
    {
        app.Logger.LogWarning(ex, "YouTube cards were not copied into the admin database.");
    }
    // Off by default so an admin price edit survives the next restart.
    if (app.Configuration.GetValue("ApplyOfficialRates", false))
        OfficialRates.Apply(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Replaces UseHttpsRedirection so HTTP upgrades are 301, not the framework default 307.
// Local hosts stay on http inside SeoRedirector. POST is not redirected.
app.UseMiddleware<SeoRedirectMiddleware>();
app.UseStatusCodePagesWithReExecute("/status/{0}");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapGet("/robots.txt", (SeoRedirector seo) =>
{
    var body = "User-agent: *\nAllow: /\n\nSitemap: " + seo.Origin + "/sitemap.xml\n";
    return Results.Text(body, "text/plain");
});

app.MapGet("/sitemap.xml", async (WWContext db, SeoRedirector seo, CancellationToken ct) =>
{
    IReadOnlyList<string> locationSlugs = Array.Empty<string>();
    var friendSlugs = new List<string>(SitemapXml.DefaultFriendSlugs);
    try
    {
        locationSlugs = (await db.Location.AsNoTracking()
            .Where(l => l.IsActive && l.Slug != null && l.Slug != "")
            .OrderBy(l => l.SortOrder)
            .Select(l => l.Slug)
            .ToListAsync(ct))
            .Select(s => s.Trim().ToLowerInvariant())
            .ToList();

        var fromDb = await db.Friends.AsNoTracking()
            .Where(f => f.IsActive && f.Slug != null && f.Slug != "")
            .OrderBy(f => f.SortOrder)
            .Select(f => f.Slug)
            .ToListAsync(ct);
        foreach (var slug in fromDb)
        {
            if (!friendSlugs.Contains(slug, StringComparer.OrdinalIgnoreCase))
                friendSlugs.Add(slug);
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogWarning(ex, "Sitemap omitted database URLs because the database could not be read.");
    }

    return Results.Text(SitemapXml.Build(seo.Origin, locationSlugs, friendSlugs), "application/xml");
});

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
