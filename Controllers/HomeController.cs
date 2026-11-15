using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WallyWombatsPublic_MVC.Models;

namespace WallyWombatsPublic_MVC.Controllers;

public class HomeController : Controller
{
	private readonly EmailService _emailService;

	private readonly WWContext _context;

	private readonly YouTubeChannelService _youtube;

	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger, WWContext context, EmailService emailService, YouTubeChannelService youtube)
	{
		_logger = logger;
		_context = context;
		_emailService = emailService;
		_youtube = youtube;
	}

	private List<Location> ActiveLocations() =>
		_context.Location.Where(l => l.IsActive).OrderBy(l => l.SortOrder).ToList();

	private HomeModel PricingHomeModel()
	{
		var locations = ActiveLocations();
		var vegasId = locations.FirstOrDefault(l => l.Slug == "las-vegas")?.Id;
		var allGa = _context.GeneralAdmission.ToList();
		var allPp = _context.PartyPackage.ToList();
		var locationRates = locations.Select(loc => new LocationPricing
		{
			Location = loc,
			GeneralAdmission = allGa.Where(g => g.LocationId == loc.Id).ToList(),
			PartyPackage = allPp.Where(p => p.LocationId == loc.Id).ToList()
		}).ToList();
		return new HomeModel
		{
			generaladmission = allGa.Where(g => g.LocationId == vegasId).ToList(),
			partypackage = allPp.Where(p => p.LocationId == vegasId).ToList(),
			LocationRates = locationRates,
			testimonial = _context.Testimonial.ToList(),
			FAQViewModel = _context.FAQ.ToList(),
			Locations = locations
		};
	}

	public async Task<IActionResult> Index()
	{
		var model = PricingHomeModel();
		try
		{
			var feed = await _youtube.GetAsync(HttpContext.RequestAborted);
			model.YouTubeShorts = feed.Shorts;
			model.YouTubeVideos = feed.Videos;
			CmsSchema.RefreshYouTube(_context, feed);
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex, "Could not load Wally Wombats YouTube clips.");
		}
		return View(model);
	}

	[Route("welcome")]
	public IActionResult Welcome()
	{
		var locations = _context.Location
			.Where(l => l.IsActive)
			.OrderBy(l => l.SortOrder)
			.ToList();
		var faq = _context.FAQ.ToList();
		// WelcomeViewModel inherits HomeModel so Jerickson's shared partials (FAQ etc.)
		// still receive a model they can bind to.
		var vm = new WelcomeViewModel
		{
			Locations = locations,
			FAQViewModel = faq
		};
		return View(vm);
	}

	[Route("pricing")]
	public IActionResult Pricing()
	{
		return View(PricingHomeModel());
	}

	[Route("book")]
	public IActionResult Find(string loc)
	{
		if (!string.IsNullOrWhiteSpace(loc))
			return RedirectToAction(nameof(Book), new { slug = loc });
		ViewData["Title"] = "Pick a location";
		return View(ActiveLocations());
	}

	[Route("book/{slug}")]
	public IActionResult Book(string slug)
	{
		var model = PricingHomeModel();
		var match = (model.LocationRates ?? new List<LocationPricing>())
			.FirstOrDefault(b => string.Equals(b.Location.Slug, slug, StringComparison.OrdinalIgnoreCase));
		if (match == null) return NotFound();
		ViewData["BookLoc"] = match.Location.Slug;
		ViewData["Title"] = "Book " + match.Location.Name;
		return View(model);
	}

	[Route("friends/{slug}")]
	public IActionResult Friend(string slug)
	{
		var pal = _context.Friends.FirstOrDefault(f => f.Slug == slug && f.IsActive)?.ToProfile()
			?? CharacterCatalog.Find(slug);
		if (pal == null) return NotFound();
		ViewData["Title"] = pal.Name;
		return View(pal);
	}

	// Old "Load more" endpoint. TempData was null on a fresh request and this threw HTTP 500.
	public IActionResult MoreBlogPost() => RedirectPermanent("/blog");

	// Old /post?id= articles. The view null-referenced when the row was missing and Google saw HTTP 500.
	[Route("post")]
	public IActionResult BlogPost() => RedirectPermanent("/blog");

	[Route("calendar")]
	public IActionResult Calendar()
	{
		var locations = ActiveLocations();
		string location = locations.FirstOrDefault()?.Name ?? "Henderson";
		DateTime date = DateTime.Now.Date;
		IList<FAQ> Faq = _context.FAQ.ToList();
		IList<CalendarEvents> cal = _context.CalendarEvents.Where((CalendarEvents e) => e.EventDate == ((DateTime)date).Date && e.EventLocation == location).ToList();
		HomeModel hm = new HomeModel
		{
			CalendarEventsViewModel = cal,
			FAQViewModel = Faq,
			Locations = locations
		};
		ViewData["EventDate"] = DateTime.Now.ToLongDateString();
		ViewData["InputDate"] = DateTime.Now.ToString("yyyy-MM-dd");
		ViewData["location"] = location;
		return View(hm);
	}

	[HttpGet]
	public IActionResult GetCalendar(DateTime date, string location)
	{
		ViewData["EventDate"] = date.ToLongDateString();
		ViewData["location"] = location;
		IList<FAQ> Faq = _context.FAQ.ToList();
		IList<CalendarEvents> Cal = _context.CalendarEvents.Where((CalendarEvents e) => e.EventDate == ((DateTime)date).Date && e.EventLocation == location).ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq,
			CalendarEventsViewModel = Cal
		};
		return PartialView("_PartialViewCalendar", hm);
	}

	[Route("contact-us")]
	public IActionResult ContactUs()
	{
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq,
			Locations = ActiveLocations()
		};
		return View(hm);
	}

	[Route("about-us")]
	public IActionResult AboutUs()
	{
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq
		};
		return View(hm);
	}

	[Route("apps")]
	public IActionResult Apps()
	{
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq
		};
		return View(hm);
	}

	[Route("menu-henderson")]
	public IActionResult MenuHenderson()
	{
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq
		};
		return View(hm);
	}

	[Route("menu-rainbow")]
	public IActionResult MenuRainbow()
	{
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq
		};
		return View(hm);
	}

	[HttpPost]
	public async Task<IActionResult> SendEmail(EmailViewModel model)
	{
		if (ModelState.IsValid)
		{
			var body = "Full Name: " + model.FirstName + " " + model.LastName + "<br />Email Address: " + model.EmailAddress + "<br />Phone Number: " + model.PhoneNumber + "<br />Message: " + model.Message;
			await _emailService.SendEmailAsync(body, model.EmailAddress);
		}
		return RedirectToAction("ContactUs");
	}

	[HttpPost]
	public async Task<IActionResult> SendEmail_Index(EmailViewModel model)
	{
		if (!Request.HasFormContentType)
			return HomeAgain();

		var loc = Request.Form["LocationName"].ToString();
		var body = "Full Name: " + model.FirstName + " " + model.LastName + "<br />Email Address: " + model.EmailAddress + "<br />Phone Number: " + model.PhoneNumber + "<br />Location: " + loc + "<br />Message: " + model.Message;
		var sent = await _emailService.SendEmailAsync(body, model.EmailAddress);
		TempData["Note"] = sent
			? "Your note is on its way to the Wally team."
			: "That note could not be sent just yet. Please write to support@wallywombats.com.";
		return HomeAgain();
	}

	[HttpGet("/Home/SendEmail_Index")]
	public IActionResult SendEmailIndexGet() => HomeAgain();

	[Route("faq")]
	public IActionResult FAQs()
	{
		IList<GeneralAdmission> generalAdmission = _context.GeneralAdmission.ToList();
		IList<PartyPackage> partyPackage = _context.PartyPackage.ToList();
		IList<Testimonial> Testimonial = _context.Testimonial.ToList();
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			generaladmission = generalAdmission,
			partypackage = partyPackage,
			testimonial = Testimonial,
			FAQViewModel = Faq
		};
		return View(hm);
	}

	[Route("privacy-policy")]
	public IActionResult Privacy()
	{
		IList<FAQ> Faq = _context.FAQ.ToList();
		HomeModel hm = new HomeModel
		{
			FAQViewModel = Faq
		};
		return View(hm);
	}

	[HttpGet("/subscribe")]
	public IActionResult SubscribeGet() => HomeAgain();

	[HttpPost("/subscribe")]
	public IActionResult Subscribe([FromForm] string email, [FromForm] string firstname, [FromForm] string lastname)
	{
		email = (email ?? "").Trim();
		firstname = (firstname ?? "").Trim();
		lastname = (lastname ?? "").Trim();
		if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || email.Length > 200)
		{
			TempData["Note"] = "Add an email address to join the list.";
			return HomeAgain();
		}

		try
		{
			var existing = _context.Subscribers.FirstOrDefault(s => s.Email == email);
			if (existing == null)
			{
				_context.Subscribers.Add(new Subscriber
				{
					Email = email,
					FirstName = firstname,
					LastName = lastname,
					DateCreated = DateTime.UtcNow
				});
			}
			else
			{
				existing.FirstName = firstname;
				existing.LastName = lastname;
				existing.DateCreated = DateTime.UtcNow;
			}

			_context.SaveChanges();
			TempData["Note"] = "You are on the list. We will write when something special is coming up.";
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex, "Mailing list signup was not saved.");
			TempData["Note"] = "The list could not be saved just yet. Please try again in a minute.";
		}

		return HomeAgain();
	}

	private ContentResult HomeAgain()
	{
		return Content(
			"<!doctype html><html><head><meta charset=\"utf-8\"><title>Wally Wombats</title></head><body><p><a href=\"/#contact\">Back to Wally Wombats</a></p><script>location.replace('/#contact');</script></body></html>",
			"text/html");
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		ViewData["Robots"] = "noindex";
		ViewData["SuppressCanonical"] = true;
		return View(new ErrorViewModel
		{
			RequestId = (Activity.Current?.Id ?? HttpContext.TraceIdentifier)
		});
	}
}
