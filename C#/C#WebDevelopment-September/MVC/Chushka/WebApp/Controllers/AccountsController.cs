namespace WebApp.Controllers
{
	using System;
	using System.Threading.Tasks;
	using global::Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.Contracts;
	using ViewModels.Account;

	public class AccountsController : Controller
	{
		public IAccountsService AccountsService { get; set; }
		private SignInManager<ChushkaUser> SignInManager { get; }

		public AccountsController(IAccountsService accountsService, SignInManager<ChushkaUser> signInManager)
		{
			this.AccountsService = accountsService;
			this.SignInManager = signInManager;
		}

		public IActionResult Login()
		{
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (this.ModelState.IsValid)
			{
				var result = await this.SignInManager.PasswordSignInAsync(model.Username,
					model.Password, false, false);

				if (result.Succeeded)
				{
					return this.RedirectToAction("Index", "Home");
				}
			}

			return this.View();
		}


		public IActionResult Register()
		{
			return this.View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (this.ModelState.IsValid)
			{
				var user = new ChushkaUser() { UserName = model.Username, Email = model.Email, FullName = model.FullName };
				var result = await this.SignInManager.UserManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await this.SignInManager.SignInAsync(user, false);
					return this.RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						this.ModelState.AddModelError("", error.Description);
					}
				}
			}
			return this.View();
		}

		public IActionResult Logout()
		{
			var user = this.User;
			this.AccountsService.LogoutUser();
			Console.WriteLine();
			return this.RedirectToAction("Index", "Home");
		}
	}
}
