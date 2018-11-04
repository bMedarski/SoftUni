namespace MishMashWebApp.Controllers
{
	using Common;
	using MIshMashData;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Users;

	public class UsersController:BaseController
	{
		private UsersService UsersService { get; set; }

		public UsersController(MishMashDbContext db,UsersService usersService)
		:base(db)
		{
			this.UsersService = usersService;
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
		public IHttpResponse Register()
		{
			return this.View();
		}

		[HttpPost]
		public IHttpResponse Register(RegisterViewModel model)
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
