namespace MishMashWebApp.Controllers
{
	using MIshMashData;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;

	public abstract class BaseController:Controller
	{
		public MishMashDbContext Db { get; set; }

		protected BaseController(MishMashDbContext db)
		{
			this.Db = db;
		}
		public IHttpResponse RedirectToHome()
		{
			return this.Redirect("/Home/Index");
		}

	}
}
