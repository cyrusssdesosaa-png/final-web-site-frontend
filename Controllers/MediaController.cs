using Microsoft.AspNetCore.Mvc;

namespace WallyWombatsPublic_MVC.Controllers;

public class MediaController : Controller
{
    private static readonly HashSet<string> Folders = new(StringComparer.OrdinalIgnoreCase)
    {
        "locations/las-vegas",
        "locations/henderson",
        "locations/bullhead-city",
        "theme/playground",
        "theme/arcade",
        "theme/parties",
        "uploads"
    };

    private readonly IConfiguration _config;
    private readonly IWebHostEnvironment _env;

    public MediaController(IConfiguration config, IWebHostEnvironment env)
    {
        _config = config;
        _env = env;
    }

    [HttpGet("/api/media")]
    public IActionResult List(string folder)
    {
        if (!Authorized()) return Unauthorized();
        if (!TryFolder(folder, out var rel, out var dir)) return BadRequest();
        if (!Directory.Exists(dir)) return Json(Array.Empty<string>());
        var web = "/" + rel;
        var files = Directory.GetFiles(dir)
            .Where(IsPicture)
            .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
            .Select(f => web + "/" + Path.GetFileName(f))
            .ToList();
        return Json(files);
    }

    [HttpPost("/api/media")]
    [RequestSizeLimit(20_000_000)]
    [RequestFormLimits(MultipartBodyLengthLimit = 20_000_000)]
    public async Task<IActionResult> Upload(IFormFile? file, string? folder, string? saveAs)
    {
        if (!Authorized()) return Unauthorized();
        if (file == null || file.Length == 0) return BadRequest("Choose a picture.");
        if (!TryFolder(folder, out var rel, out var dir)) return BadRequest("That folder is not allowed.");
        if (!IsPicture(file.FileName)) return BadRequest("Use a jpg, png, or webp picture.");

        var name = string.IsNullOrWhiteSpace(saveAs) ? Path.GetFileName(file.FileName) : Path.GetFileName(saveAs);
        name = name.Replace(" ", "-");
        if (!IsPicture(name)) return BadRequest("Use a jpg, png, or webp picture.");

        Directory.CreateDirectory(dir);
        var path = Path.Combine(dir, name);
        await using (var stream = System.IO.File.Create(path))
        {
            await file.CopyToAsync(stream);
        }

        return Json(new { path = "/" + rel + "/" + name });
    }

    private bool Authorized()
    {
        var expected = _config["UploadKey"];
        if (string.IsNullOrWhiteSpace(expected)) return false;
        var given = Request.Headers["X-Upload-Key"].ToString();
        return string.Equals(expected, given, StringComparison.Ordinal);
    }

    private bool TryFolder(string? folder, out string rel, out string dir)
    {
        var key = (folder ?? "").Replace('\\', '/').Trim('/');
        rel = "";
        dir = "";
        if (!Folders.Contains(key)) return false;
        rel = key == "uploads" ? "uploads" : "img/" + key;
        dir = Path.Combine(_env.WebRootPath, rel.Replace('/', Path.DirectorySeparatorChar));
        return true;
    }

    private static bool IsPicture(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
            || ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)
            || ext.Equals(".png", StringComparison.OrdinalIgnoreCase)
            || ext.Equals(".webp", StringComparison.OrdinalIgnoreCase);
    }
}
