namespace IRuneWebApp.Controllers
{
	using Models;
	using Services.Contracts;
	using SIS.MvcFramework.ActionResults.Contracts;
	using SIS.MvcFramework.Attributes.Method;
	using SIS.MvcFramework.Controllers;
	using SIS.MvcFramework.Security;

	public class UsersController : Controller
	{
		private readonly IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			this.ViewModel["SignIn"] = "hidden";
			this.ViewModel["SignOff"] = "";
			return this.View();
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{

			if (!this.ModelState.IsValid.HasValue || !this.ModelState.IsValid.Value)
			{
				this.ViewModel.Data["error"] = "Wrong login data";
				return this.RedirectToAction("/Users/Login");
			}
			var username = model.Username;
			var passwordHash = this.userService.HashPassword(model.Password);

			var user = this.userService.GetUser(username, username, passwordHash);

			if (user == null)
			{
				return this.View();
			}
			else
			{
				this.ViewModel["SignIn"] = "";
				this.ViewModel["SignOff"] = "hidden";

				this.SignIn(new IdentityUser { Username = model.Username, Password = passwordHash });
				return this.RedirectToAction("/");
			}
		}

		[HttpGet]
		public IActionResult Register()
		{
			this.ViewModel["SignIn"] = "hidden";
			this.ViewModel["SignOff"] = "";
			return this.View();
		}
		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (!this.ModelState.IsValid.HasValue || !this.ModelState.IsValid.Value)
			{
				this.ViewModel.Data["error"] = "Wrong register data";
				return this.RedirectToAction("/Users/Login");
			}
			var username = model.Username;
			var password = model.Password;
			var confirmPassword = model.ConfirmPassword;
			var email = model.Email;
			if (password != confirmPassword)
			{
				this.ViewModel.Data["error"] = "Passwords not the same";
				return this.View();
			}
			var passwordHash = this.userService.HashPassword(password);

			if (this.userService.GetUser(username, email, password) != null)
			{
				this.ViewModel.Data["error"] = "Already such an user";
				return this.View();
			}
			this.userService.CreateUser(username, email, passwordHash);
			this.ViewModel["SignIn"] = "";
			this.ViewModel["SignOff"] = "hidden";
			
			this.SignIn(new IdentityUser { Username = model.Username, Password = passwordHash });
			return this.RedirectToAction("/");
		}

		public IActionResult Logout()
		{
			this.SignOut();
			return this.RedirectToAction("/");
		}
	}
}
