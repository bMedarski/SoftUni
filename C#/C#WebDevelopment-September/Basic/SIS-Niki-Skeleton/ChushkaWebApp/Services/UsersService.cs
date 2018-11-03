﻿namespace ChushkaWebApp.Services
{
	using System.Linq;
	using ChushkaData;
	using ChushkaModels;
	using Microsoft.EntityFrameworkCore.Internal;
	using SIS.MvcFramework.Services;
	using ViewModels.Users;

	public class UsersService
	{
		private readonly HashService hashService;
		private readonly ChushkaDb Db;

		public UsersService(ChushkaDb db,HashService hashService)
		{
			this.Db = db;
			this.hashService = hashService;
		}

		public User CreateUser(RegisterViewModel model)
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
				FullName = model.FullName.Trim(),
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
