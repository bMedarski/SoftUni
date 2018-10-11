namespace IRuneWebApp.Controllers
{
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public class HomeController:BaseController
	{
		public IHttpResponse Index(IHttpRequest request)
		{
			if (this.userService.IsAuthenticated(request))
			{
				return new RedirectResult("/Home/SignIn");
			}
			this.viewBag["Title"]="Home";
			this.viewBag["SignIn"] = "hidden";
			this.viewBag["SignOff"] = "";
			return this.View();
		}

		public IHttpResponse SignIndex(IHttpRequest request)
		{
			if (!this.userService.IsAuthenticated(request))
			{
				return new RedirectResult("");
			}
			this.viewBag["Title"]="Home";
			this.viewBag["SignIn"] = "";
			this.viewBag["SignOff"] = "hidden";
			this.viewBag["Username"] = request.Session.GetParameter("username").ToString();
			return this.View();
		}
	}
}
