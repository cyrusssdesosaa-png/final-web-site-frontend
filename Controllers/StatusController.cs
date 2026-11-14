using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WallyWombatsPublic_MVC.Controllers;

public class StatusController : Controller
{
    [HttpGet("/status/{code:int}")]
    public IActionResult Handle(int code)
    {
        if (code < 400 || code > 599)
            code = 404;

        Response.StatusCode = code;
        var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
        var original = feature?.OriginalPath;
        if (original != null && original.StartsWith("/api", StringComparison.OrdinalIgnoreCase))
            return new EmptyResult();

        ViewData["StatusCode"] = code;
        ViewData["OriginalPath"] = original;
        ViewData["Robots"] = "noindex";
        ViewData["SuppressCanonical"] = true;
        return View("StatusCode");
    }
}
