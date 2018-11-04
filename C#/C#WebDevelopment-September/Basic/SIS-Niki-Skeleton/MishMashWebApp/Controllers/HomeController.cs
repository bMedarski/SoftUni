namespace MishMashWebApp.Controllers
{
	using MIshMashData;
	using SIS.HTTP.Responses;

	public class HomeController:BaseController
	{
		public HomeController(MishMashDbContext dbContext)
		:base(dbContext)
		{
			
		}

		public IHttpResponse Index()
		{
			if (this.User.IsLoggedIn)
			{
				return this.View();
			}
			return this.View();
		}
	}
}
