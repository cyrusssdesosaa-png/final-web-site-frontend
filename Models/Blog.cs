using System;

namespace WallyWombatsPublic_MVC.Models;

public class Blog
{
	public int Id { get; set; }

	public DateTime DateCreated { get; set; }

	public string? Title { get; set; }

	public string? Slug { get; set; }

	public string? Summary { get; set; }

	public string? Description { get; set; }

	public string? AuthorName { get; set; }

	public string? CategoryName { get; set; }

	public string? FeaturedImage { get; set; }

	public bool IsFeaturedPost { get; set; }

	public bool IsPublished { get; set; }
}
