using System.IO;
using CHUSHKA.App.Services;
using CHUSHKA.Data;
using SoftUni.WebServer.Mvc.Controllers;
using SoftUni.WebServer.Mvc.Interfaces;

namespace CHUSHKA.App.Controllers
{
    public class BaseController:Controller
    {
	    protected readonly UsersService users;
	    protected readonly ProductsService products;

		protected BaseController()
	    {
		    this.users = new UsersService();
			this.products = new ProductsService();

			this.Db = new ChuskaContex();
		    this.ViewData["anonymousDisplay"] = "flex";
		    this.ViewData["displayAddNote"] = "none";
		    this.ViewData["alertDisplay"] = "none";
		    this.ViewData.Data["show-error"] = "none";

		    var noUser = File.ReadAllText("./Views/Partials/register_login-nav.html");
		    this.ViewData.Data["nav"] = noUser;
	    }
	    protected void ShowError(string error)
	    {
		    this.ViewData.Data["show-error"] = "block";
		    this.ViewData.Data["error"] = error;
	    }

	    protected void ShowAlert(string alert)
	    {
		    this.ViewData.Data["alertDisplay"] = "block";
		    this.ViewData.Data["alertMessage"] = alert;
	    }
		protected ChuskaContex Db { get; private set; }

	    protected IActionResult RedirectToHome()
	    {
		    return this.RedirectToAction("/home/index");
	    }

	    protected IActionResult RedirectToLogin()
	    {
		    return this.RedirectToAction("/users/login");
	    }

	}
}
