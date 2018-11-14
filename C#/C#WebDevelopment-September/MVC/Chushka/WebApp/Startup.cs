using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data;

namespace WebApp
{
	using global::Models;
	using Services;
	using Services.Contracts;
	using Utilities;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<ChushkaDbContext>(options =>
				options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
			
			services.AddIdentity<ChushkaUser,IdentityRole>(options =>
				{
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
					options.Password.RequiredLength = 3;
					options.Password.RequiredUniqueChars = 1;
				})
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<ChushkaDbContext>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddTransient<IAccountsService, AccountsService>();
			services.AddTransient<IProductsService, ProductsService>();
			services.AddTransient<IOrdersService, OrdersService>();
			services.AddTransient<ICounter, Counter>();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Account/Login";
				options.LogoutPath = $"/Account/Logout";
				options.AccessDeniedPath = $"/Account/AccessDenied";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,RoleManager<IdentityRole> roleManager,UserManager<ChushkaUser> userManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			Seeder.SeedRoles(roleManager,userManager);

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
