namespace Eventures.Services.AccountServices
{
	using Contracts;
	using EventuresModel;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Account;

	public class AccountService : IAccountService
	{

		private SignInManager<EventuresUser> SignInManager { get; }
		private UserManager<EventuresUser> UserManager { get; }

		public AccountService(SignInManager<EventuresUser> signInManager, UserManager<EventuresUser> userManager)
		{
			this.SignInManager = signInManager;
			this.UserManager = userManager;
		}

		public IdentityResult CreateUser(RegisterViewModel model)
		{
			var user = new EventuresUser()
			{
				UserName = model.UserName,
				Email = model.Email,
				UniqueCitizenNumber = model.UniqueCitizenNumber,
				FirstName = model.FirstName,
				LastName = model.LastName,
			};
			var result = this.UserManager.CreateAsync(user, model.Password).Result;
			if (result.Succeeded)
			{

				this.SignInUser(user, model.Password);
			}
			return result;
		}

		public async void SignInUser(EventuresUser user, string password)
		{
			await this.SignInManager.PasswordSignInAsync(user, password, false, false);
		}
		public async void LogoutUser()
		{
			await this.SignInManager.SignOutAsync();
			return;
		}
	}
}
