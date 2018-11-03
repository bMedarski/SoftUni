namespace AirportApp.Services
{
	using System.Linq;
	using AirportData;
	using AirportModels;
	using Microsoft.EntityFrameworkCore.Internal;
	using SIS.MvcFramework.Services;
	using ViewModels.Users;

	public class UsersService
	{
		private readonly HashService hashService;
		private readonly AirportDb Db;

		public UsersService(HashService hashService)
		{
			this.Db = new AirportDb();
			this.hashService = hashService;
		}

		public User CreateUser(RegisterInputViewModel model)
		{
			var hashedPassword = this.hashService.Hash(model.Password);

			var role = Role.User;
			if (!EnumerableExtensions.Any(this.Db.Users))
			{
				role = Role.Admin;
			}
			var user = new User
			{
				Username = model.Username.Trim(),
				Email = model.Email.Trim(),
				Password = hashedPassword,
				Role = role
			};
			this.Db.Users.Add(user);
			this.Db.SaveChanges();
			return user;
		}

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			var hashedPassword = this.hashService.Hash(password);

			var user = this.Db.Users.Where(u => u.Username == username && u.Password == hashedPassword)
				.FirstOrDefault();
			return user;
		}
		public User GetUserByUsername(string username)
		{
			var user = this.Db.Users.Where(u=>u.Username==username).FirstOrDefault();
			return user;
		}
	}
}
