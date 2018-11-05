namespace PandaWebApp.Controllers
{
	using Common;
	using Models.BindingModels.Users;
	using PandaDatabase;
	using PandaModel;
	using Services.Contracts;
	using SIS.HTTP.Cookies;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;

	public class UsersController:BaseController
	{
		private IUsersService UsersService { get; }

		public UsersController(PandaDbContext db, IUsersService usersService) : base(db)
		{
			this.UsersService = usersService;
		}
		private void SignIn(User user)
		{
			var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString() };
			var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

			var cookie = new HttpCookie(Constants.CookieAuthKey, cookieContent, Constants.CookieExpirationDays) { HttpOnly = true };
			this.Response.Cookies.Add(cookie);
		}

		private void SignOff()
		{
			if (this.Request.Cookies.ContainsCookie(Constants.CookieAuthKey))
			{
				var cookie = this.Request.Cookies.GetCookie(Constants.CookieAuthKey);
				cookie.Delete();
				this.Response.Cookies.Add(cookie);
			}
		}
		[Authorize]
		public IHttpResponse Logout()
		{
			this.SignOff();
			return this.RedirectToHome();
		}

		public IHttpResponse Login()
		{
			return this.View();
		}

		[HttpPost]
		public IHttpResponse Login(LoginBindingModel model)
		{
			var user = this.UsersService.GetUserByUsernameAndPassword(model.Username, model.Password);

			if (user == null)
			{
				return this.BadRequestErrorWithView(Constants.WrongUserNameOrPassword);
			}
			this.SignIn(user);
			return this.RedirectToHome();
		}
		public IHttpResponse Register()
		{
			return this.View();
		}

		[HttpPost]
		public IHttpResponse Register(RegisterBindingModel model)
		{
			if (this.UsersService.GetUserByUsername(model.Username) != null)
			{
				return this.BadRequestErrorWithView(Constants.DuplicateUserIdMessage);
			}

			var validation = this.ValidateUser(model);
			
			if (validation != "")
			{
				return this.BadRequestErrorWithView(validation);
			}

			var user = this.UsersService.CreateUser(model);
			this.SignIn(user);
			return this.RedirectToHome();
		}
		private string ValidateUser(RegisterBindingModel model)
		{

			if (!Validator.AreTheSame(model.Password, model.ConfirmPassword))
			{
				return Constants.InvalidConfirmPasswordMessage;
			}
			if (!Validator.IfContainsSymbol(model.Email, Constants.EmailRequiredCharacter))
			{
				return Constants.InvalidEmailMessage;
			}
			return "";
		}
	}
}
