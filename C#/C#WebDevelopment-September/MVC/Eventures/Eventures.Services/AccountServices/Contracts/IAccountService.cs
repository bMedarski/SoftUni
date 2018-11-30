namespace Eventures.Services.AccountServices.Contracts
{
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Account;

	public interface IAccountService
	{
		IdentityResult CreateUser(RegisterViewModel model);
		void LogoutUser();
	}
}
