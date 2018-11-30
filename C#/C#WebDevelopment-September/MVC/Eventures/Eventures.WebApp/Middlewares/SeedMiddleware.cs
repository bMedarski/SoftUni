namespace Eventures.WebApp.Middlewares
{
	using System.Threading.Tasks;
	using Data;
	using EventuresModel;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;
	using Utilities;

	public class SeedMiddleware
	{
		private readonly RequestDelegate next;
		private RoleManager<IdentityRole> roleManager;
		private UserManager<EventuresUser> userManager;

		public SeedMiddleware(RequestDelegate next)
		{
			this.next = next;

		}

		public async Task InvokeAsync(HttpContext httpContext, EventuresDbContext dbContext,RoleManager<IdentityRole> roleManager,UserManager<EventuresUser> userManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
			this.SeedRoles(roleManager,userManager);
			
			await this.next(httpContext);
		}
		public void SeedRoles(RoleManager<IdentityRole> rm,UserManager<EventuresUser> um)
		{

			if (!rm.RoleExistsAsync
				("User").Result)
			{
				IdentityRole role = new IdentityRole("User");
				IdentityResult roleResult = rm.
					CreateAsync(role).Result;
			}
			if (!rm.RoleExistsAsync
				(GlobalConstants.AdminRoleText).Result)
			{
				IdentityRole role = new IdentityRole();
				role.Name = GlobalConstants.AdminRoleText;
				IdentityResult roleResult = rm.
					CreateAsync(role).Result;
			}

			if (um.FindByNameAsync
				    ("admin").Result == null)
			{
				EventuresUser user = new EventuresUser();
				user.UserName = "admin";
				user.Email = "admin@admin";
				user.FirstName = "admin";
				user.LastName = "admin";
				user.UniqueCitizenNumber = 0123456789;

				IdentityResult result = um.CreateAsync
					(user, "admin").Result;

				if (result.Succeeded)
				{
					um.AddToRoleAsync(user,
						GlobalConstants.AdminRoleText).Wait();
				}
			}
		}
	}
}
