using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WallyWombatsPublic_MVC.Models;

namespace WallyWombatsPublic_MVC.Controllers;

/// <summary>
/// Public-facing single-location page at /locations/{slug}.
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
    /// GET /locations/{slug}  — e.g. /locations/henderson
    /// Returns 404 if slug is missing, unknown, or the location is deactivated.
    /// </summary>
    [HttpGet("locations/{slug}")]
    public async Task<IActionResult> Detail(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return NotFound();

        var normalized = slug.Trim().ToLowerInvariant();
        var location = await _context.Location.FirstOrDefaultAsync(l =>
            l.IsActive && l.Slug != null && l.Slug.ToLower() == normalized);
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
    /// GET /locations — the club list lives on the homepage. Permanent, not the old 302.
    /// </summary>
    [HttpGet("locations")]
    public IActionResult Index() => RedirectPermanent("/#locations");
}
