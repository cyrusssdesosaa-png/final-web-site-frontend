using System.ComponentModel.DataAnnotations;

namespace WallyWombatsPublic_MVC.Models;

/// <summary>
/// A physical Wally Wombats indoor-playground location. Mirror of the admin
/// Location class — Jerickson's convention is a separate copy per project.
/// </summary>
public class Location
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Slug { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(300)]
    public string? Address { get; set; }

    [StringLength(30)]
    public string? Phone { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? HoursMonFri { get; set; }

    [StringLength(50)]
    public string? HoursSatSun { get; set; }

    [StringLength(500)]
    public string? WaiverUrl { get; set; }

    [StringLength(500)]
    public string? TicketsUrl { get; set; }

    [StringLength(500)]
    public string? YoutubeUrl { get; set; }

    [StringLength(500)]
    public string? HeroImageUrl { get; set; }

    [StringLength(1000)]
    public string? MapEmbedUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public int SortOrder { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public bool ShowPromo { get; set; }

    [StringLength(200)]
    public string? PromoHeadline { get; set; }

    [StringLength(2000)]
    public string? PromoBody { get; set; }
}
