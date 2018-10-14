using System.IO;
using System.Text;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Interfaces;

namespace PeakStats.Controllers
{
	public class HomeController : BaseController
	{

		[HttpGet]
		public IActionResult Index()
		{
			int? userId = null;
			//if (!this.User.IsAuthenticated)
			//{
			//	var guestFormat = File.ReadAllText("./Views/Home/guest.html");
			//	this.Model["guest"] = guestFormat;
			//	this.Model["user"] = string.Empty;
			//	return View();
			//}

			var username = this.User.Name;
			//userId = this.users.GetByName(this.User.Name).Id;

			//var tubeCards = this.tubes.All().Select(g => g.ToHtml()).ToList();

			//var result = new StringBuilder();

			//for (int i = 0; i < tubeCards.Count; i++)
			//{
			//	if (i % 3 == 0)
			//	{
			//		result.Append(@"<div class=""card-group col-12 justify-content-center"">");
			//	}

			//	result.Append(tubeCards[i]);

			//	if (i % 3 == 2 || i == tubeCards.Count - 1)
			//	{
			//		result.Append("</div>");
			//	}
			//}

			//var userFormat = File.ReadAllText("../../../Views/Home/user.html");

			//this.GetUserIdForNavBar();

			//this.Model.Data["user"] = userFormat;
			//this.Model.Data["username"] = username;
			//this.Model.Data["userhome"] = result.ToString();

			//this.Model["guest"] = string.Empty;

			return this.View();
		}
	}
}
