namespace PandaWebApp.Controllers
{
	using Common;
	using Models.BindingModels.Packages;
	using Models.ViewModels.Packages;
	using PandaDatabase;
	using Services.Contracts;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;

	public class PackagesController:BaseController
	{
		private IPackagesService PackagesService { get; }
		private  IUsersService UsersService { get; }

		public PackagesController(PandaDbContext db, IPackagesService packagesService,IUsersService userService) : base(db)
		{
			this.PackagesService = packagesService;
			this.UsersService = userService;
		}

		[Authorize("Admin")]
		public IHttpResponse Create()
		{
			var users = this.UsersService.GetAllUsersNames();
			var model = new CreatePackageUserListViewModel {Users = users};
			return this.View(model);
		}

		[Authorize("Admin")]
		[HttpPost]
		public IHttpResponse Create(CreatePackageBindingModel model)
		{
			var user = this.UsersService.GetUserByUsername(model.Recipient);
			if (user == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchUserName);
			}
			this.PackagesService.CreatePackage(model);
			return this.RedirectToHome();
		}

		[Authorize]
		public IHttpResponse Details(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				return this.BadRequestError(Constants.NoSuchPackageId);
			}

			return this.View(package);
		}

		[Authorize("Admin")]
		public IHttpResponse Pending()
		{
			var packages =
				this.PackagesService.GetAllPendingPackages();
			var model = new PackagesListViewModel{Packages=packages};
			return this.View(model);
		}
		[Authorize("Admin")]
		public IHttpResponse Shipped()
		{
			var packages =
				this.PackagesService.GetAllShippedPackages();
			var model = new PackagesListViewModel{Packages=packages};
			return this.View(model);
		}
		[Authorize("Admin")]
		public IHttpResponse Delivered()
		{
			var packages =
				this.PackagesService.GetAllDeliveredPackages();
			var model = new PackagesListViewModel{Packages=packages};
			return this.View(model);
		}
		[Authorize("Admin")]
		public IHttpResponse Ship(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				return this.BadRequestError(Constants.NoSuchPackageId);
			}
			this.PackagesService.Ship(id);
			return this.Redirect("/Packages/Pending");
		}
		[Authorize("Admin")]
		public IHttpResponse Deliver(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				return this.BadRequestError(Constants.NoSuchPackageId);
			}
			this.PackagesService.Deliver(id);
			return this.Redirect("/Packages/Delivered");
		}
		[Authorize]
		public IHttpResponse Acquire(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				return this.BadRequestError(Constants.NoSuchPackageId);
			}

			if (package.Recipient != this.User.Username)
			{
				return this.BadRequestError(Constants.InvalidAcquiredMessage);
			}

			this.PackagesService.Acquire(id,this.User.Username);
			return this.RedirectToHome();
		}
	}
}
