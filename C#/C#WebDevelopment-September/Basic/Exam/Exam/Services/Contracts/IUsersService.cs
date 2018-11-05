namespace PandaWebApp.Services.Contracts
{
	using System.Collections.Generic;
	using Models.BindingModels.Users;
	using Models.ViewModels.Packages;
	using PandaModel;

	public interface IUsersService
	{
		User GetUserByUsername(string username);
		User GetUserByUsernameAndPassword(string username, string password);
		User CreateUser(RegisterBindingModel model);
		IList<PackageViewModel> GetAllUsersNames();
	}
}
