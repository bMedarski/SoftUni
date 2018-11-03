namespace AirportApp.Controllers
{
	using SIS.HTTP.Responses;

	public class HomeController:BaseController
	{

		public IHttpResponse Index()
		{
			if (!this.User.IsLoggedIn)
			{
				return this.Redirect("/Users/Login");
			}

			return this.View();
		}
	}
}
