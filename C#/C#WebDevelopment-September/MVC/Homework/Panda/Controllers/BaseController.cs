namespace Panda.Controllers
{
	using Data;
	using Microsoft.AspNetCore.Mvc;

	public abstract class BaseController:Controller
	{
		protected ApplicationDbContext Db { get; set; }

		protected BaseController(ApplicationDbContext db)
		{
			this.Db = db;
		}
		
		protected IActionResult RedirectToHome()
		{
			return this.Redirect("/Home/Index");
		}

	}
}
