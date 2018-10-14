using System.IO;
using System.Linq;
using System.Text;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;

namespace CHUSHKA.App.Controllers
{
	public class HomeController : BaseController
	{

		[HttpGet]
		public IActionResult Index()
		{
			int? userId = null;
			if (!this.User.IsAuthenticated)
			{
				var guestFormat = File.ReadAllText("./Views/Home/guest.html");
				this.ViewData["guest"] = guestFormat;
				this.ViewData["user"] = string.Empty;
				this.ViewData["admin"] = string.Empty;
				return View();
			}

			var username = this.User.Name;
			userId = this.users.GetByName(this.User.Name).Id;

			var products = this.products.All().ToList();

			var result = new StringBuilder();

			for (int i = 0; i < products.Count; i++)
			{
				result.AppendLine($"<a href = \"/products/details?id={products[i].Id}\" class=\"col-md-2\">");
				result.AppendLine($"<div class=\"product p-1 chushka-bg-color rounded-top rounded-bottom\">");
				result.AppendLine($"<h5 class=\"text-center mt-3\">{products[i].Name}</h5>");
				result.AppendLine($"<hr class=\"hr-1 bg-white\"/>");
				if (products[i].Description.Length > 50)
				{
					var desc = products[i].Description.Substring(0, 50) + "...";
					result.AppendLine($"<p class=\"text-white text-center\">{desc}</p>");
				}
				else
				{
					result.AppendLine($"<p class=\"text-white text-center\">{products[i].Description}</p>");
				}
				result.AppendLine($"<hr class=\"hr-1 bg-white\"/>");
				result.AppendLine($"<h6 class=\"text-center text-white mb-3\">${products[i].Price}</h6>");
				result.AppendLine($"</div>");
				result.AppendLine($"</a>");
			}

			var userFormat = File.ReadAllText("./Views/Home/user.html");
			this.ViewData.Data["user"] = userFormat;
			this.ViewData.Data["userhome"] = result.ToString();
			this.ViewData["guest"] = string.Empty;
			var userNav = "";

			var role = this.User.IsInRole("user");

			if (this.User.IsInRole("Admin"))
			{
				userNav = File.ReadAllText("./Views/Partials/admin-nav.html");
			}
			else
			{
				userNav = File.ReadAllText("./Views/Partials/registered_user-nav.html");
			}
			
			this.ViewData["nav"] = userNav;
			this.ViewData["username"] = username;

			return this.View();
		}
	}
}
