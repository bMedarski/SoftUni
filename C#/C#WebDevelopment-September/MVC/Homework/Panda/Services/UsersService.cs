namespace Panda.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Data;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Packages;

	public class UsersService :IUsersService
	{
		private ApplicationDbContext Db { get; }
		private readonly UserManager<User> _userManager;

		public UsersService(ApplicationDbContext db,UserManager<User> userManager)
		{
			this.Db = db;
			this._userManager = userManager;
		}

		//public User GetUserByUsernameAndPassword(string username, string password)
		//{
		//	var hashedPassword = this._userManager.PasswordHasher.VerifyHashedPassword()
		//	return this.Db.Users.FirstOrDefault(u => u.UserName == username && u.PasswordHash == hashedPassword);
		//}
		public User GetUserByUsername(string username)
		{
			return this.Db.Users.Where(u => u.UserName == username).FirstOrDefault();
		}

		public IList<PackageViewModel> GetAllUsersNames()
		{
			return this.Db.Users.Select(u => new PackageViewModel
			{
				Name = u.UserName,
			}).ToList();
		}
	}
}
