namespace Eventures.WebApp.Services.AccountServices
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	using Contracts;
	using Data;
	using EventuresModel;
	using Microsoft.AspNetCore.Identity;
	using Utilities;
	using ViewModels.Account;

	public class AccountService : IAccountService
	{
		private readonly IMapper autoMapper;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly EventuresDbContext context;

		private SignInManager<EventuresUser> SignInManager { get; }
		private UserManager<EventuresUser> UserManager { get; }

		public AccountService(EventuresDbContext context,RoleManager<IdentityRole>roleManager,SignInManager<EventuresUser> signInManager, UserManager<EventuresUser> userManager,IMapper autoMapper)
		{
			this.context = context;
			this.roleManager = roleManager;
			this.autoMapper = autoMapper;
			this.SignInManager = signInManager;
			this.UserManager = userManager;
		}

		public void CreateUserExternal(string email, ExternalLoginInfo info)
		{
			var user = this.UserManager.FindByEmailAsync(email).Result;
			if (user == null)
			{
				user = new EventuresUser { UserName = email, Email = email };
				var result = this.UserManager.CreateAsync(user).Result;
			}

			this.SignInManager.SignInAsync(user, false).GetAwaiter().GetResult();
		}
		public void CreateUser(RegisterViewModel model)
		{
			var user = this.autoMapper.Map<EventuresUser>(model);
			var result = this.UserManager.CreateAsync(user, model.Password).Result;
			if (result.Succeeded)
			{
				this.SignInUser(user, model.Password);
			}
		}

		public async void SignInUser(EventuresUser user, string password)
		{
			await this.SignInManager.PasswordSignInAsync(user, password, false, false);
		}
		public async void LogoutUser()
		{
			await this.SignInManager.SignOutAsync();
		}

		public IList<AdminPanelUsersViewModel> AdminPanelUsers()
		{
			var users = new List<AdminPanelUsersViewModel>();
			foreach (var u in this.UserManager.Users.ToList())
			{
				var user = new AdminPanelUsersViewModel
				{
					Username = u.UserName,
					Id = u.Id
				};
				var roleId = this.context.UserRoles.Where(r => r.UserId == u.Id).FirstOrDefault();
				if (roleId != null)
				{
					user.Role = this.roleManager.Roles.Where(r => r.Id == roleId.RoleId).FirstOrDefault().Name;
				}

				users.Add(user);
			}
			return users;
		}

		public void Promote(string id)
		{
			var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
			this.UserManager.AddToRoleAsync(user,GlobalConstants.AdminRoleText).GetAwaiter().GetResult();
		}

		public void Demote(string id)
		{
			var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
			this.UserManager.RemoveFromRoleAsync(user,GlobalConstants.AdminRoleText).GetAwaiter().GetResult();
		}
	}
}
