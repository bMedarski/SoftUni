namespace Panda.Services.Contracts
{
	using System.Collections.Generic;
	using Data;
	using ViewModels.Packages;

	public interface IUsersService
	{
		//User GetUserByUsername(string username);
		//User GetUserByUsernameAndPassword(string username, string password);
		IList<PackageViewModel> GetAllUsersNames();
	}
}
