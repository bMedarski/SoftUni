namespace MishMashWebApp.Controllers
{
	using MIshMashData;

	public class HomeController:BaseController
	{
		public HomeController(MishMashDbContext dbContext)
		:base(dbContext)
		{
			
		}
	}
}
