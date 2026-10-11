namespace WallyWombatsPublic_MVC.Models;

public class PartyPackage
{
	public int Id { get; set; }

	public string? PackageCategory { get; set; }

	public string? PackageImage { get; set; }

	public string? PackageName { get; set; }

	public decimal PackagePrice { get; set; }

	public string? PackageDescription { get; set; }

	// Added Oct 2026 — nullable FK to Location.
	public int? LocationId { get; set; }
}
