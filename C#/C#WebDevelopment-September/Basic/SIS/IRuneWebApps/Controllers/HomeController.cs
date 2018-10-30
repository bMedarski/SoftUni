namespace IRuneWebApp.Controllers
{
	using SIS.MvcFramework.ActionResults.Contracts;
	using SIS.MvcFramework.Controllers;

	public class HomeController:Controller
	{
		public IActionResult Index()
		{
			if (this.Identity() != null)
			{
				this.ViewModel.Data["SignIn"] = "";
				this.ViewModel.Data["SignOff"] = "hidden";
				return this.RedirectToAction("/Home/SignIn");
			}
			this.ViewModel.Data["SignIn"] = "hidden";
			this.ViewModel.Data["SignOff"] = "";
			return this.View();
		}

		public IActionResult SignIn()
		{
			if (this.Identity() == null)
			{
				this.ViewModel.Data["SignIn"] = "";
				this.ViewModel.Data["SignOff"] = "hidden";
				return this.RedirectToAction("/Home/Index");
			}
			this.ViewModel.Data["SignIn"] = "";
			this.ViewModel.Data["SignOff"] = "hidden";
			this.ViewModel.Data["Username"] = this.Identity().Username;
			return this.View();
		}
	}
}
