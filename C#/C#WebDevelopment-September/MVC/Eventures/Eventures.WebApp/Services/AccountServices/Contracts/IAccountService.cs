namespace Eventures.WebApp.Services.AccountServices.Contracts
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Account;

	public interface IAccountService
	{
		void CreateUser(RegisterViewModel model);
		void CreateUserExternal(string email,ExternalLoginInfo info);
		IList<AdminPanelUsersViewModel> AdminPanelUsers();
		void LogoutUser();
		void Demote(string id);
		void Promote(string id);
	}
}
