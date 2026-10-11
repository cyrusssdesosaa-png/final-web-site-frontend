using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WallyWombatsPublic_MVC.Models;

namespace WallyWombatsPublic_MVC.Controllers;

/// <summary>
/// Public-facing single-location page at /Locations/{slug}.
/// Added Oct 2026 to support the "pick your location" architecture.
/// Admin manages Location data at admin.wallywombats.com/Locations.
/// </summary>
public class LocationsController : Controller
{
    private readonly WWContext _context;

    public LocationsController(WWContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET /Locations/{slug}  — e.g. /Locations/henderson
    /// Returns 404 if slug is missing, unknown, or the location is deactivated.
    /// </summary>
    [HttpGet("Locations/{slug}")]
    public async Task<IActionResult> Detail(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return NotFound();

        var location = await _context.Location.FirstOrDefaultAsync(l =>
            l.Slug == slug && l.IsActive);
        if (location == null)
            return NotFound();

        var vm = new LocationPageViewModel
        {
            Location          = location,
            GeneralAdmissions = await _context.GeneralAdmission
                                     .Where(g => g.LocationId == location.Id)
                                     .OrderBy(g => g.GAGroup)   // Weekday / Weekend
                                     .ThenBy(g => g.GAPrice)
                                     .ToListAsync(),
            PartyPackages     = await _context.PartyPackage
                                     .Where(p => p.LocationId == location.Id
                                         && (p.PackageCategory == "Weekdays" || p.PackageCategory == "Weekend"))
                                     .OrderBy(p => p.PackageCategory)
                                     .ThenBy(p => p.PackagePrice)
                                     .ToListAsync(),
            FAQs              = await _context.FAQ.ToListAsync(),
            Testimonials      = await _context.Testimonial
                                     .OrderByDescending(t => t.DateCreated)
                                     .Take(6)
                                     .ToListAsync(),
            OtherLocations    = await _context.Location
                                     .Where(l => l.IsActive && l.Id != location.Id)
                                     .OrderBy(l => l.SortOrder)
                                     .ToListAsync(),
        };

        return View(vm);
    }

    /// <summary>
    /// GET /Locations — redirects to home (which will later host the location picker grid).
    /// Phase C may replace this with a dedicated picker page.
    /// </summary>
    [HttpGet("Locations")]
    public IActionResult Index() => RedirectToAction("Index", "Home");
}
