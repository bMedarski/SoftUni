namespace IRuneWebApp.Controllers
{
	using Common;
	using Extensions;
	using SIS.HTTP.Enums;
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public class UsersController:BaseController
	{
		private const string TitleLoginPage = "Login page";
		private const string TitleRegistrationPage = "Registration page";
		public IHttpResponse Login(IHttpRequest request)
		{
			//if method is GET return view
			if (request.RequestMethod==HttpRequestMethod.Get)
			{
				this.viewBag["Title"] = TitleLoginPage;
				this.viewBag["SignIn"] = "hidden";
				this.viewBag["SignOff"] = "";
				return this.View();
			}
			else
			{
				//get parameters from request
				var username = request.FormData["username"].ToString().Trim();
				var password = request.FormData["password"].ToString();
				var passwordHash = this.userService.HashPassword(password);

				//get user from db
				var user = this.userService.GetUser(username, username, passwordHash);

				//if no user return error page 
				if (user == null)
				{
					this.viewBag["Error"] = "Wrong username or password";
					return this.View(BadRequestViewName,"Common");
				}
				else
				{
					this.viewBag["SignIn"] = "";
					this.viewBag["SignOff"] = "hidden";
					var cookie = this.userService.SignIn(username, request);

					var response = new RedirectResult("/Home/SignIn");
					response.AddCookie(cookie);
					return response;
				}
			}
		}
		public IHttpResponse Register(IHttpRequest request)
		{
			if (request.RequestMethod == HttpRequestMethod.Get)
			{
				this.viewBag["Title"] = TitleRegistrationPage;
				this.viewBag["SignIn"] = "hidden";
				this.viewBag["SignOff"] = "";
				return this.View();
			}
			else
			{
				var username = request.FormData["username"].ToString().Trim();
				var password = request.FormData["password"].ToString();
				var confirmPassword = request.FormData["confirmPassword"].ToString();
				var email = request.FormData["email"].ToString().Decode();
				if (password != confirmPassword)
				{
					this.viewBag["Error"] = "Passwords not the same";
					return this.View(BadRequestViewName,"Common");
				}
				var passwordHash = this.userService.HashPassword(password);

				if (this.userService.GetUser(username, email, password) != null)
				{
					this.viewBag["Error"] = "Already such an user";
					return this.View(BadRequestViewName,"Common");
				}
				this.userService.CreateUser(username, email, passwordHash);
				this.viewBag["SignIn"] = "";
				this.viewBag["SignOff"] = "hidden";
				var authCookie = this.userService.SignIn(username, request);
				var response = new RedirectResult("/");
				response.AddCookie(authCookie);
				return response;
			}
		}

		public IHttpResponse Logout(IHttpRequest request)
		{
			request.Session.GetParameter("username");
			//Clear username data from session
			request.Session.ClearParameters();	
			//get and delete cookie
			var cookie = request.Cookies.GetCookie(Constants.AuthentificationKey);
			cookie.Delete();
			var response = new RedirectResult("/");
			response.AddCookie(cookie);
			return response;
		}
	}
}
