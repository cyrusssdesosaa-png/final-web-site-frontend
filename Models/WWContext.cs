using Microsoft.EntityFrameworkCore;

namespace WallyWombatsPublic_MVC.Models;

public class WWContext : DbContext
{
	public DbSet<GeneralAdmission> GeneralAdmission { get; set; }

	public DbSet<CalendarEvents> CalendarEvents { get; set; }

	public DbSet<PartyPackage> PartyPackage { get; set; }

	public DbSet<Testimonial> Testimonial { get; set; }

	public DbSet<Blog> Blog { get; set; }

	public DbSet<FAQ> FAQ { get; set; }

	// Added Oct 2026 — per-location pricing + promo popups + location picker.
	public DbSet<Location> Location { get; set; }

	public DbSet<SocialCard> SocialCards { get; set; }

	public DbSet<SiteSetting> SiteSettings { get; set; }

	public DbSet<Users> Users { get; set; }

	public DbSet<Friend> Friends { get; set; }

	public DbSet<Subscriber> Subscribers { get; set; }

	public WWContext(DbContextOptions<WWContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Fix the EF warning Jerickson's original code triggered.
		modelBuilder.Entity<GeneralAdmission>().Property(e => e.GAPrice).HasPrecision(10, 2);
		modelBuilder.Entity<PartyPackage>().Property(e => e.PackagePrice).HasPrecision(10, 2);

		modelBuilder.Entity<Location>().HasIndex(l => l.Slug).IsUnique();
		modelBuilder.Entity<SiteSetting>().HasIndex(s => s.SettingKey).IsUnique();
		modelBuilder.Entity<SocialCard>().Property(s => s.Platform).HasMaxLength(40);
		modelBuilder.Entity<SocialCard>().Property(s => s.Title).HasMaxLength(300);
		modelBuilder.Entity<Subscriber>().ToTable("Subscribers");
		modelBuilder.Entity<Subscriber>().HasIndex(s => s.Email).IsUnique();
		modelBuilder.Entity<Subscriber>().Property(s => s.Email).HasMaxLength(200);
		modelBuilder.Entity<Subscriber>().Property(s => s.FirstName).HasMaxLength(120);
		modelBuilder.Entity<Subscriber>().Property(s => s.LastName).HasMaxLength(120);
	}
}
