namespace TorshiaWebApp.Controllers
{
	using Common;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Users;

	public class UsersController:BaseController
	{
		public UsersController(UsersService userService,ValidateService validateService)
		{
			this.ValidateService = validateService;
			this.UsersService = userService;
		}
		private UsersService UsersService { get; set; }
		private ValidateService ValidateService { get; set; }

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
		public IHttpResponse Register()
		{
			return this.View();
		}

		[HttpPost]
		public IHttpResponse Register(RegisterViewModel model)
		{
			var validation = this.ValidateService.ValidateUser(model);
			if (validation != "")
			{
				return this.BadRequestErrorWithView(validation);
			}
			if (this.UsersService.GetUserByUsername(model.Username) != null)
			{
				return this.BadRequestErrorWithView(Constants.DuplicateUserIdMessage);
			}
			var user = this.UsersService.CreateUser(model);
			this.SignIn(user);
			return this.RedirectToHome();
		}
		[HttpPost]
		public IHttpResponse Login(LoginViewModel model)
		{
			var user = this.UsersService.GetUserByUsernameAndPassword(model.Username, model.Password);

			if (user == null)
			{
				return this.BadRequestErrorWithView(Constants.WrongUserNameOrPassword);
			}
			this.SignIn(user);
			return this.RedirectToHome();
		}
	}
}
