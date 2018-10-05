namespace IRuneWebApp.Controllers
{
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;

	public class HomeController:BaseContoller
	{
		public IHttpResponse Index(IHttpRequest request)
		{
			return this.View();
		}
	}
}
