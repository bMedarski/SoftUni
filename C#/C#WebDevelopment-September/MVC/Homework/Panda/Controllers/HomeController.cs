namespace Panda.Controllers
{
	using System.Diagnostics;
	using Common;
	using Data;
	using Microsoft.AspNetCore.Mvc;
	using Models;
	using Services.Contracts;
	using ViewModels.Home;

	public class HomeController : BaseController
	{
		private IPackageService PackageService { get; set; }
		public HomeController(ApplicationDbContext db,IPackageService packageService) : base(db)
		{
			this.PackageService = packageService;
		}

		public IActionResult Index()
		{
			if (this.User.Identity.IsAuthenticated)
			{
				var model = new HomeViewModel
				{
					PendingPackages = this.PackageService.GetAllPackagesByStatus(Constants.PackageStatusPending, this.User.Identity.Name),
					ShippedPackages = this.PackageService.GetAllPackagesByStatus(Constants.PackageStatusShipped, this.User.Identity.Name),
					DeliveredPackages = this.PackageService.GetAllPackagesByStatus(Constants.PackageStatusDelivered, this.User.Identity.Name)
				};
				return this.View("IndexLogged",model);
			}
			return this.View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}


	}
}
