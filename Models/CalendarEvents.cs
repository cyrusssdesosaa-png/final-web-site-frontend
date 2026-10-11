using System;

namespace WallyWombatsPublic_MVC.Models;

public class CalendarEvents
{
	public int Id { get; set; }

	public DateTime EventDate { get; set; }

	public string? EventTimeStart { get; set; }

	public string? EventTimeEnd { get; set; }

	public string? EventDetails { get; set; }

	public string? EventTitle { get; set; }

	public string? EventPlace { get; set; }

	public string? EventLocation { get; set; }
}
