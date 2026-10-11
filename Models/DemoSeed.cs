using Microsoft.EntityFrameworkCore;

namespace WallyWombatsPublic_MVC.Models;

public static class DemoSeed
{
    public static bool ShouldUseDemo(IConfiguration config, string connectionName)
    {
        if (config.GetValue<bool>("DemoMode")) return true;
        if (string.Equals(Environment.GetEnvironmentVariable("WW_DEMO"), "1", StringComparison.OrdinalIgnoreCase)) return true;
        var cs = config.GetConnectionString(connectionName);
        if (string.IsNullOrWhiteSpace(cs) || cs.Contains("REPLACED_IN", StringComparison.OrdinalIgnoreCase)) return true;
        try
        {
            using var conn = new Microsoft.Data.SqlClient.SqlConnection(cs);
            conn.Open();
            return false;
        }
        catch
        {
            return true;
        }
    }

    public static void Ensure(WWContext db)
    {
        if (db.Location.Any()) return;

        var rainbow = Loc("las-vegas", "North Rainbow", "3165 N. Rainbow Boulevard, Las Vegas, NV 89108", "702-463-6555",
            "https://ecom.roller.app/wallywombatsrainbow/playgroundcheckout/en-us/home", "/img/AOP/ww-004.jpg", 10);
        var henderson = Loc("henderson", "Henderson", "611 Mall Ring Circle Henderson, NV 89014", "702-483-5900",
            "https://ecom.roller.app/wallywombatshenderson/buynow/en-us/products", "/img/AOP/ww-006.jpg", 20);
        var bullhead = Loc("bullhead-city", "Bullhead City", "2135 Highway 95, Suite 125, Bullhead City, AZ 86442", "928-235-6858",
            "https://ecom.roller.app/wallywombatsbullheadcity/buynow/en-us/products", "/img/AOP/ww-006.jpg", 30);
        db.Location.AddRange(rainbow, henderson, bullhead);
        db.SaveChanges();

        foreach (var loc in new[] { rainbow, henderson, bullhead })
        {
            var child = loc.Slug == "bullhead-city"
                ? new decimal[] { 15, 28, 42, 56 }
                : new decimal[] { 19, 36, 54, 72 };
            for (var i = 0; i < child.Length; i++)
            {
                db.GeneralAdmission.Add(Ga(loc.Id, "Weekdays", child[i], i + 1));
                db.GeneralAdmission.Add(Ga(loc.Id, "Weekend", child[i], i + 1));
            }

            AddParties(db, loc.Id, loc.Slug == "bullhead-city" ? (125m, 395m) : (175m, 395m));
        }

        void Specials(int locId, decimal toddler, decimal bedtime, decimal ems)
        {
            db.GeneralAdmission.AddRange(
                new GeneralAdmission { LocationId = locId, GACategory = "Special", GAName = "Toddler Time", GAPrice = toddler, GAInclusion = "Monday to Friday 9AM-12PM. Children 1-4 years old." },
                new GeneralAdmission { LocationId = locId, GACategory = "Special", GAName = "Bedtime Play", GAPrice = bedtime, GAInclusion = "Monday to Friday 7PM-9PM. All ages." },
                new GeneralAdmission { LocationId = locId, GACategory = "Special", GAName = "EMS Kids", GAPrice = ems, GAInclusion = "Medical professionals, active military and law enforcement parents. Any time or day." }
            );
        }
        Specials(rainbow.Id, 15, 15, 15);
        Specials(henderson.Id, 15, 15, 15);
        Specials(bullhead.Id, 12.50m, 12.50m, 12.50m);

        db.FAQ.AddRange(
            new FAQ { Category = "General", Question = "What does general admission include?", Answer = "Unlimited access to all play areas during your visit. Keep your receipt and you can return later the same day." },
            new FAQ { Category = "General", Question = "Do adults need to purchase a ticket?", Answer = "No. Every paying child includes entry for up to two accompanying adults." },
            new FAQ { Category = "General", Question = "What should we bring?", Answer = "Socks are required inside the playground. A change of clothes is also helpful for active little explorers." },
            new FAQ { Category = "General", Question = "Is parking available?", Answer = "Yes. All Wally Wombats locations offer free on-site parking." }
        );

        db.Testimonial.AddRange(
            new Testimonial { CommentBy = "Carol T.", Comments = "Our kids absolutely love this place! It is one of the few indoor playgrounds that feels incredibly hygienic.", DateCreated = DateTime.UtcNow.AddDays(-20) },
            new Testimonial { CommentBy = "Alexia G.", Comments = "Had my baby's first birthday party here and everything was above and beyond.", DateCreated = DateTime.UtcNow.AddDays(-12) },
            new Testimonial { CommentBy = "Kamila O.", Comments = "Great space. My 3-year-old and 6-year-old had a complete blast.", DateCreated = DateTime.UtcNow.AddDays(-6) }
        );

        db.SaveChanges();
    }

    private static Location Loc(string slug, string name, string address, string phone, string tickets, string hero, int sort) => new()
    {
        Slug = slug,
        Name = name,
        Address = address,
        Phone = phone,
        HoursMonFri = "9:00 am - 9:00 pm",
        HoursSatSun = "10:00 am - 9:00 pm",
        TicketsUrl = tickets,
        WaiverUrl = tickets,
        HeroImageUrl = hero,
        IsActive = true,
        SortOrder = sort
    };

    private static GeneralAdmission Ga(int locationId, string day, decimal price, int n) => new()
    {
        LocationId = locationId,
        GACategory = day,
        GAName = n + " Child",
        GAPrice = price,
        GAGroup = day
    };

    private static void AddParties(WWContext db, int locationId, (decimal vp, decimal yp) passes)
    {
        var parties = new (string name, decimal weekday, decimal weekend, string desc)[]
        {
            ("Bilby Party", 250, 350, "Up to 5 children, $30 additional per child"),
            ("Tassie Party", 400, 500, "Up to 10 children, $30 additional per child"),
            ("Wallaby Party", 550, 650, "Up to 15 children, $30 additional per child"),
            ("Emu Party", 700, 800, "Up to 20 children, $30 additional per child")
        };
        foreach (var day in new[] { "Weekdays", "Weekend" })
        {
            foreach (var p in parties)
            {
                db.PartyPackage.Add(new PartyPackage
                {
                    LocationId = locationId,
                    PackageCategory = day,
                    PackageName = p.name,
                    PackagePrice = day == "Weekend" ? p.weekend : p.weekday,
                    PackageDescription = p.desc,
                    PackageImage = "~/img/theme/parties/" + p.name.Split(' ')[0].ToLowerInvariant() + "-package.jpg"
                });
            }
        }

        db.PartyPackage.Add(new PartyPackage { LocationId = locationId, PackageCategory = "MembershipVP", PackageName = "10 Visit Pass", PackagePrice = passes.vp, PackageDescription = "Ten visits at the location you purchased it." });
        db.PartyPackage.Add(new PartyPackage { LocationId = locationId, PackageCategory = "MembershipYP", PackageName = "Yearly Pass", PackagePrice = passes.yp, PackageDescription = "Unlimited visits for one year at the location you purchased it." });
        db.PartyPackage.Add(new PartyPackage { LocationId = locationId, PackageCategory = "MembershipVP1", PackageName = "10 Visit include", PackagePrice = 0, PackageDescription = "Enjoy 10 visits to our indoor playground for a discounted rate. Can only be used at the location you purchased it at." });
        db.PartyPackage.Add(new PartyPackage { LocationId = locationId, PackageCategory = "MembershipYP1", PackageName = "Yearly include", PackagePrice = 0, PackageDescription = "Unlimited visits to our indoor playground for an entire year. Can only be used at the location you purchased it at." });
    }
}
