namespace PandaWebApp.Controllers
{
	using PandaDatabase;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;

	public abstract class BaseController:Controller
	{
		protected PandaDbContext Db { get; set; }

		protected BaseController(PandaDbContext db)
		{
			this.Db = db;
		}
		
		protected IHttpResponse RedirectToHome()
		{
			return this.Redirect("/Home/Index");
		}

	}
}
