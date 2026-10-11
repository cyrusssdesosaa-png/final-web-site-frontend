using System.Collections.Generic;

namespace WallyWombatsPublic_MVC.Models;

/// <summary>
/// Bundle a Location + its filtered pricing + the global FAQ list for the
/// public /Locations/{slug} page.
/// </summary>
public class LocationPageViewModel
{
    public Location Location { get; set; } = new();

    /// <summary>General admission tiers that belong to this location (filtered by LocationId).</summary>
    public IList<GeneralAdmission> GeneralAdmissions { get; set; } = new List<GeneralAdmission>();

    /// <summary>Party packages that belong to this location.</summary>
    public IList<PartyPackage> PartyPackages { get; set; } = new List<PartyPackage>();

    /// <summary>Global FAQ list — rendered in the footer section, same as other public pages.</summary>
    public IList<FAQ> FAQs { get; set; } = new List<FAQ>();

    /// <summary>Testimonials — rendered above the FAQ section.</summary>
    public IList<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    /// <summary>All active locations — rendered in the "visit our other locations" footer card row.</summary>
    public IList<Location> OtherLocations { get; set; } = new List<Location>();
}
