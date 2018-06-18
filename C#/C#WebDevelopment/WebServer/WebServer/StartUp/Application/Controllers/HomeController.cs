namespace StartUp.Application.Controllers
{
	using Views;
	using Server.Enums;
	using Server.HTTP.Contracts;
	using Server.HTTP.Response;

	public class HomeController
	{
		public IHttpResponse Index()
		{
			return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
		}
	}
}