namespace PandaWebApp.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Microsoft.EntityFrameworkCore.Internal;
	using Models.BindingModels.Users;
	using Models.ViewModels.Packages;
	using PandaDatabase;
	using PandaModel;
	using SIS.MvcFramework.Services;

	public class UsersService :IUsersService
	{
		private PandaDbContext Db { get; }
		private IHashService HashService { get; }

		public UsersService(PandaDbContext db,IHashService hashService)
		{
			this.Db = db;
			this.HashService = hashService;
		}
		public User CreateUser(RegisterBindingModel model)
		{
			var hashedPassword = this.HashService.Hash(model.Password);

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
				Role = role,
			};
			this.Db.Users.Add(user);
			this.Db.SaveChanges();
			return user;
		}

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			var hashedPassword = this.HashService.Hash(password);
			return this.Db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
		}
		public User GetUserByUsername(string username)
		{
			return this.Db.Users.Where(u=>u.Username==username).FirstOrDefault();
		}

		public IList<PackageViewModel> GetAllUsersNames()
		{
			return this.Db.Users.Select(u => new PackageViewModel
			{
				Name = u.Username,
			}).ToList();
		}
	}
}
