namespace WallyWombatsPublic_MVC.Models;

public class GeneralAdmission
{
	public int Id { get; set; }

	public string? GAGroup { get; set; }

	public string? GAName { get; set; }

	public decimal GAPrice { get; set; }

	public string? GACategory { get; set; }

	public string? GAInclusion { get; set; }

	// Added Oct 2026 — nullable FK (see migration 001_add_locations.sql).
	public int? LocationId { get; set; }
}
