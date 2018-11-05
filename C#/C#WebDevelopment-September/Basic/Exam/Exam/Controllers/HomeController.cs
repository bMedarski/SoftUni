namespace PandaWebApp.Controllers
{
	using System.Collections.Generic;
	using Common;
	using Models.ViewModels.Home;
	using Models.ViewModels.Packages;
	using PandaDatabase;
	using Services.Contracts;
	using SIS.HTTP.Responses;

	public class HomeController:BaseController
	{
		private IPackagesService PackagesService { get; }
		public HomeController(PandaDbContext db,IPackagesService packagesService)
		:base(db)
		{
			this.PackagesService = packagesService;
		}

		public IHttpResponse Index()
		{
			if (this.User.IsLoggedIn)
			{
				IList<PackageViewModel> pendingPackages;
				IList<PackageViewModel> shippedPackages;
				IList<PackageViewModel> deliveredPackages;

					pendingPackages =
						this.PackagesService.GetAllPackagesByStatus(Constants.PackageStatusPending, this.User.Username);
					shippedPackages =
						this.PackagesService.GetAllPackagesByStatus(Constants.PackageStatusShipped, this.User.Username);
					deliveredPackages =
						this.PackagesService.GetAllPackagesByStatus(Constants.PackageStatusDelivered, this.User.Username);
				var model = new HomeViewModel
				{
					PendingPackages = pendingPackages,
					ShippedPackages = shippedPackages,
					DeliveredPackages = deliveredPackages,
				};
				return this.View("/Home/IndexLogged",model);
			}
			return this.View();
		}
	}
}
