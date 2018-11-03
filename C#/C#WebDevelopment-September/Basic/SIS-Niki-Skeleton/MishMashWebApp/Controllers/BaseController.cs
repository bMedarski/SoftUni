namespace MishMashWebApp.Controllers
{
	using MIshMashData;
	using SIS.MvcFramework;

	public abstract class BaseController:Controller
	{
		public MishMashDbContext Db { get; set; }

		protected BaseController(MishMashDbContext db)
		{
			this.Db = db;
		}


	}
}
