using System.Collections.Generic;

namespace WallyWombatsPublic_MVC.Models;

public class HomeModel
{
	public IList<GeneralAdmission> generaladmission { get; set; }

	public IList<PartyPackage> partypackage { get; set; }

	public IList<Testimonial> testimonial { get; set; }

	public IList<EmailViewModel> EmailViewModel { get; set; }

	public IList<FAQ> FAQViewModel { get; set; }

	public IList<CalendarEvents> CalendarEventsViewModel { get; set; }

	public IList<Blog> BlogPosts { get; set; }

	public IList<Blog> BlogViewModel { get; set; }

	public Blog blog { get; set; }

	public IList<Location> Locations { get; set; }

	public IList<GeneralAdmission> BullheadAdmission { get; set; }

	public IList<LocationPricing> LocationRates { get; set; }

	public IList<YouTubeClip> YouTubeShorts { get; set; } = new List<YouTubeClip>();

	public IList<YouTubeClip> YouTubeVideos { get; set; } = new List<YouTubeClip>();
}

public class LocationPricing
{
	public Location Location { get; set; }

	public IList<GeneralAdmission> GeneralAdmission { get; set; }

	public IList<PartyPackage> PartyPackage { get; set; }
}
