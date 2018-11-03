namespace TorshiaWebApp.Controllers
{
	using Common;
	using SIS.HTTP.Cookies;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using TorshiaData;
	using TorshiaModels;

	public abstract class BaseController:Controller
	{
		public BaseController()
		{
			this.Db = new TorshiaDb();
		}
		public TorshiaDb Db { get; set; }

		public IHttpResponse RedirectToHome()
		{
			return this.Redirect("/Home/Index");
		}
		public void SignIn(User user)
		{
			this.UserCookieService.GetType();
			var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString() };
			var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

			var cookie = new HttpCookie(Constants.CookieAuthKey, cookieContent, Constants.CookieExpirationDays) { HttpOnly = true };
			this.Response.Cookies.Add(cookie);
		}

		public void SignOff()
		{
			if (this.Request.Cookies.ContainsCookie(Constants.CookieAuthKey))
			{
				var cookie = this.Request.Cookies.GetCookie(Constants.CookieAuthKey);
				cookie.Delete();
				this.Response.Cookies.Add(cookie);
			}
		}
	}
}
