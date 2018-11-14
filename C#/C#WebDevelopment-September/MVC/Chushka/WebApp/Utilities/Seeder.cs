namespace WebApp.Utilities
{
	using global::Models;
	using Microsoft.AspNetCore.Identity;

	public static class Seeder
	{

		public static void SeedRoles
			(RoleManager<IdentityRole> roleManager,UserManager<ChushkaUser> userManager)
		{
			if (!roleManager.RoleExistsAsync
				("User").Result)
			{
				IdentityRole role = new IdentityRole();
				role.Name = "User";
				IdentityResult roleResult = roleManager.
					CreateAsync(role).Result;
			}


			if (!roleManager.RoleExistsAsync
				(GlobalConstants.AdminRoleText).Result)
			{
				IdentityRole role = new IdentityRole();
				role.Name = GlobalConstants.AdminRoleText;
				IdentityResult roleResult = roleManager.
					CreateAsync(role).Result;
			}

			if (userManager.FindByNameAsync
				    ("admin").Result == null)
			{
				ChushkaUser user = new ChushkaUser();
				user.UserName = "admin";
				user.Email = "admin@admin";
				user.FullName = "admin";

				IdentityResult result = userManager.CreateAsync
					(user, "admin").Result;

				if (result.Succeeded)
				{
					userManager.AddToRoleAsync(user,
						GlobalConstants.AdminRoleText).Wait();
				}
			}
		}
	}
}
