namespace AirportApp
{
	using Common;
	using Controllers;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Users;

	public class UsersController : BaseController
	{
		private readonly UsersService usersService;

		public UsersController(UsersService usersService)
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
		public IHttpResponse Login(LoginInputViewModel model)
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
		public IHttpResponse Register(RegisterInputViewModel model)
		{
			var validation = this.ValidateUser(model);
			if (validation != "")
			{
				return this.BadRequestErrorWithView(validation);
			}

			if (this.usersService.GetUserByUsernameAndPassword(model.Username, model.Password) != null)
			{
				return this.BadRequestErrorWithView(Constants.DuplicateUserIdMessage);
			}
			var user = this.usersService.CreateUser(model);
			this.SignIn(user);
			return this.RedirectToHome();
		}
		private string ValidateUser(RegisterInputViewModel model)
		{
			if (!Validator.IfContainsSymbol(model.Email, Constants.EmailRequiredCharacter))
			{
				return Constants.InvalidEmailMessage;
			}

			if (!Validator.AreTheSame(model.Password, model.ConfirmPassword))
			{
				return Constants.InvalidRepeatPasswordMessage;
			}

			return "";
		}
	}

}
