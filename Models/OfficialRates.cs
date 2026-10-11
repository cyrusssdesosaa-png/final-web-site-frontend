namespace WallyWombatsPublic_MVC.Models;

public static class OfficialRates
{
    public static void Apply(WWContext db)
    {
        if (!db.Location.Any()) return;

        Sync(db, "las-vegas", new[] { 19m, 36m, 54m, 72m }, 15m, 15m, 15m, 175m, 395m, 17.50m);
        Sync(db, "henderson", new[] { 19m, 36m, 54m, 72m }, 15m, 15m, 15m, 175m, 395m, 17.50m);
        Sync(db, "bullhead-city", new[] { 15m, 28m, 42m, 56m }, 12.50m, 12.50m, 12.50m, 125m, 395m, 12.50m);
        db.SaveChanges();
    }

    private static void Sync(
        WWContext db,
        string slug,
        decimal[] child,
        decimal toddler,
        decimal bedtime,
        decimal ems,
        decimal tenPass,
        decimal yearPass,
        decimal tenEach)
    {
        var loc = db.Location.FirstOrDefault(l => l.Slug == slug);
        if (loc == null) return;

        var ga = db.GeneralAdmission.Where(g => g.LocationId == loc.Id).ToList();
        foreach (var day in new[] { "Weekdays", "Weekend" })
        {
            for (var n = 1; n <= child.Length; n++)
            {
                var row = ga.FirstOrDefault(g =>
                    g.GACategory == day && ChildNumber(g.GAName) == n);
                if (row == null)
                {
                    row = new GeneralAdmission
                    {
                        LocationId = loc.Id,
                        GACategory = day,
                        GAGroup = day,
                        GAName = n + " Child"
                    };
                    db.GeneralAdmission.Add(row);
                    ga.Add(row);
                }
                row.GAName = n + " Child";
                row.GAPrice = child[n - 1];
            }

            foreach (var extra in ga.Where(g => g.GACategory == day && ChildNumber(g.GAName) > child.Length).ToList())
            {
                db.GeneralAdmission.Remove(extra);
                ga.Remove(extra);
            }
        }

        UpsertSpecial(db, ga, loc.Id, "Toddler Time", toddler, "Monday to Friday 9AM-12PM. Children 1-4 years old.");
        UpsertSpecial(db, ga, loc.Id, "Bedtime Play", bedtime, "Monday to Friday 7PM-9PM. All ages.");
        UpsertSpecial(db, ga, loc.Id, "EMS Kids", ems, "Medical professionals, active military and law enforcement parents. Any time or day.");

        var pkgs = db.PartyPackage.Where(p => p.LocationId == loc.Id).ToList();
        UpsertPass(db, pkgs, loc.Id, "MembershipVP", "10 Visit Pass", tenPass, "Ten visits at the location you purchased it.");
        UpsertPass(db, pkgs, loc.Id, "MembershipYP", "Annual Membership", yearPass, "Unlimited visits for one year at the location you purchased it.");
        UpsertPass(db, pkgs, loc.Id, "MembershipVP1", "10 Visit include", 0,
            "Enjoy 10 visits to our indoor playground for the discounted rate of just $" + tenEach.ToString("0.00") + " per visit. Can only be used at the location you purchased it at.");
        UpsertPass(db, pkgs, loc.Id, "MembershipYP1", "Yearly include", 0, "Unlimited visits to our indoor playground for an entire year. Can only be used at the location you purchased it at.");
    }

    private static void UpsertSpecial(WWContext db, List<GeneralAdmission> ga, int locId, string name, decimal price, string blurb)
    {
        var row = ga.FirstOrDefault(g => g.GACategory == "Special" && string.Equals(g.GAName, name, StringComparison.OrdinalIgnoreCase));
        if (row == null)
        {
            row = new GeneralAdmission
            {
                LocationId = locId,
                GACategory = "Special",
                GAGroup = "Special",
                GAName = name
            };
            db.GeneralAdmission.Add(row);
            ga.Add(row);
        }
        row.GAPrice = price;
        row.GAInclusion = blurb;
    }

    private static void UpsertPass(WWContext db, List<PartyPackage> pkgs, int locId, string category, string name, decimal price, string desc)
    {
        var row = pkgs.FirstOrDefault(p => p.PackageCategory == category);
        if (row == null)
        {
            row = new PartyPackage
            {
                LocationId = locId,
                PackageCategory = category
            };
            db.PartyPackage.Add(row);
            pkgs.Add(row);
        }
        row.PackageName = name;
        row.PackagePrice = price;
        row.PackageDescription = desc;
    }

    private static int ChildNumber(string? name)
    {
        var text = (name ?? "").Trim();
        if (text.StartsWith("One", StringComparison.OrdinalIgnoreCase)) return 1;
        if (text.StartsWith("Two", StringComparison.OrdinalIgnoreCase)) return 2;
        if (text.StartsWith("Three", StringComparison.OrdinalIgnoreCase)) return 3;
        if (text.StartsWith("Four", StringComparison.OrdinalIgnoreCase)) return 4;
        if (text.StartsWith("Five", StringComparison.OrdinalIgnoreCase)) return 5;
        var digits = new string(text.TakeWhile(char.IsDigit).ToArray());
        return int.TryParse(digits, out var n) ? n : 0;
    }
}
