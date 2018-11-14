namespace WebApp.Services.Contracts
{
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Account;

	public interface IAccountsService
	{
		IdentityResult CreateUser(RegisterViewModel model);
		void LogoutUser();
	}
}
