namespace IRuneWebApps.Controllers
{
	using SIS.HTTP.Enums;
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public class HomeController
	{
		public IHttpResponse Index(IHttpRequest request)
		{
			return new HtmlResult("Home",HttpResponseStatusCode.Ok);
		}
	}
}
