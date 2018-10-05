namespace IRuneWebApp.Controllers
{
	using SIS.HTTP.Enums;
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public class HomeController:BaseContoller
	{
		public IHttpResponse Index(IHttpRequest request)
		{


			return this.View();
		}
	}
}
