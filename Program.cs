using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using WallyWombatsPublic_MVC.Models;

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

if (!useDemo && !app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
