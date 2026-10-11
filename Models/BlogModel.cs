using System.Collections.Generic;

namespace WallyWombatsPublic_MVC.Models;

public class BlogModel
{
	public Blog blog { get; set; }

	public IList<Blog> blogposts { get; set; }
}
