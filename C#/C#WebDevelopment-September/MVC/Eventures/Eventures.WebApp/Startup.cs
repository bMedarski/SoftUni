using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.WebApp
{
	using AutoMapper;
	using Controllers;
	using Data;
	using EventuresModel;
	using Filter;
	using Microsoft.AspNetCore.Authentication.Google;
	using Microsoft.Extensions.Logging;
	using Middlewares.Extensions;
	using Services.AccountServices;
	using Services.AccountServices.Contracts;
	using Services.EventsServices;
	using Services.EventsServices.Contracts;
	using Services.OrdersServices;
	using Services.OrdersServices.Contracts;
	using Utilities;
	using Utilities.Contracts;
	using ViewModels.Account;
	using ViewModels.Events;
	using ViewModels.Orders;

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

			services.AddDbContext<EventuresDbContext>(options =>
				options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<EventuresUser,IdentityRole>(options =>
				{
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
					options.Password.RequiredLength = 3;
					options.Password.RequiredUniqueChars = 1;
				})
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<EventuresDbContext>();

			services.AddTransient<IEventsService, EventsService>();
			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<IOrdersService, OrdersService>();
			services.AddTransient<ICounter, Counter>();
			services.AddTransient<LogEventActionFilter>();

			services.AddLogging(configure => configure.AddConsole()) 
				.AddTransient<LogEventActionFilter>()
				.AddTransient<EventsController>();

			services.AddAuthentication()
				.AddFacebook(facebookOptions =>
				{
					facebookOptions.AppId = this.Configuration["Authentication:Facebook:AppId"];
					facebookOptions.AppSecret = this.Configuration["Authentication:Facebook:AppSecret"];
				})
				.AddGoogle(googleOptions =>
				{
					googleOptions.ClientId = this.Configuration["Authentication:Google:ClientId"];
					googleOptions.ClientSecret = this.Configuration["Authentication:Google:ClientSecret"];
				})
				.AddGitHub(gitHubOptions =>
				{
					gitHubOptions.ClientId = this.Configuration["Authentication:GitHub:ClientId"];
					gitHubOptions.ClientSecret = this.Configuration["Authentication:GitHub:ClientSecret"];
				});

			services.AddAutoMapper(config =>
			{
				config.CreateMap<CreateEventViewModel, EventuresEvent>().ForMember(s=>s.TicketPrice,opt=>opt.MapFrom(d=>d.PricePerTicket));
				config.CreateMap<MyEventsViewModel, EventuresEvent>();
				config.CreateMap<EventViewModel, EventuresEvent>();
				config.CreateMap<EventuresUser, RegisterViewModel>();
				config.CreateMap<RegisterViewModel, EventuresUser>();
				config.CreateMap<OrdersViewModel, EventuresOrder>();
				config.CreateMap<EventuresOrder, OrdersViewModel>()
					.ForMember(o => o.Event, opt => opt.MapFrom(d => d.Event.Name));
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Account/Login";
				options.LogoutPath = $"/Account/Logout";
				options.AccessDeniedPath = $"/Account/AccessDenied";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,RoleManager<IdentityRole> roleManager,UserManager<EventuresUser> userManager)
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
			
			app.UseSeedMiddleware();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
