using System;

namespace WallyWombatsPublic_MVC.Models;

public class Testimonial
{
	public int Id { get; set; }

	public string? Comments { get; set; }

	public string? CommentBy { get; set; }

	public string? CommentByPicture { get; set; }

	public DateTime DateCreated { get; set; }
}
