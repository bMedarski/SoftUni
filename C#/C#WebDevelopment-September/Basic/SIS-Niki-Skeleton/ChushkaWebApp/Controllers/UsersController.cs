namespace ChushkaWebApp.Controllers
{
	using ChushkaData;
	using Common;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Users;

	public class UsersController:BaseController
	{
		private readonly UsersService usersService;

		public UsersController(ChushkaDb db,UsersService usersService)
			:base(db)
		{
			this.usersService = usersService;
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
		public IHttpResponse Login(LoginnViewModel model)
		{
			var user = this.usersService.GetUserByUsernameAndPassword(model.Username, model.Password);

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
		public IHttpResponse Register(RegisterViewModel model)
		{
			if (this.usersService.GetUserByUsername(model.Username) != null)
			{
				return this.BadRequestErrorWithView(Constants.DuplicateUserIdMessage);
			}

			var validation = this.ValidateUser(model);
			
			if (validation != "")
			{
				return this.BadRequestErrorWithView(validation);
			}

			var user = this.usersService.CreateUser(model);
			this.SignIn(user);
			return this.RedirectToHome();
		}
		private string ValidateUser(RegisterViewModel model)
		{

			if (!Validator.AreTheSame(model.Password, model.ConfirmPassword))
			{
				return Constants.InvalidRepeatPasswordMessage;
			}

			return "";
		}
	}
}
