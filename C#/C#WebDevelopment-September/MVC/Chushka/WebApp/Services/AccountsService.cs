namespace WebApp.Services
{
	using Contracts;
	using global::Models;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Account;

	public class AccountsService:IAccountsService
	{
		private SignInManager<ChushkaUser> SignInManager { get; }
		private UserManager<ChushkaUser> UserManager { get; }

		public AccountsService(SignInManager<ChushkaUser> signInManager, UserManager<ChushkaUser> userManager)
		{
			this.SignInManager = signInManager;
			this.UserManager = userManager;
		}

		public IdentityResult CreateUser(RegisterViewModel model)
		{
			var user = new ChushkaUser()
			{
				UserName = model.Username,
				Email = model.Email,
				FullName = model.FullName,
			};
			var result = this.UserManager.CreateAsync(user, model.Password).Result;
			if (result.Succeeded)
			{

				this.SignInUser(user,model.Password);
			}
			return result;
		}

		public async void SignInUser(ChushkaUser user,string password)
		{
			await this.SignInManager.PasswordSignInAsync(user,password,false,false);
		}
		public async void LogoutUser()
		{
			await this.SignInManager.SignOutAsync();
			return;
		}
	}
}
