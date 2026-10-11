namespace WallyWombatsPublic_MVC.Models;

public static class Money
{
	public static string Display(decimal amount)
	{
		return amount == decimal.Truncate(amount)
			? amount.ToString("0")
			: amount.ToString("0.00");
	}
}
