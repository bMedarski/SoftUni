namespace Panda.Controllers
{
	using System.Linq;
	using Common;
	using Data;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Contracts;
	using ViewModels.Packages;

	public class PackagesController:BaseController
	{
		private IPackageService PackagesService { get; }
		private  IUsersService UsersService { get; }

		public PackagesController(ApplicationDbContext db, IPackageService packagesService,IUsersService userService) : base(db)
		{
			this.PackagesService = packagesService;
			this.UsersService = userService;
		}

		[Authorize(Roles="Admin")]
		public IActionResult Create()
		{
			var users = this.UsersService.GetAllUsersNames();
			var model = new CreatePackageUserListViewModel {Users = users};
			return this.View(model);
		}

		[Authorize(Roles="Admin")]
		[HttpPost]
		public IActionResult Create(CreatePackageBindingModel model)
		{
			var user = this.Db.Users.Where(u => u.UserName == model.Recipient);
			//var user = this.UsersService.GetUserByUsername(model.Recipient);
			if (user == null)
			{
				//return this.BadRequestErrorWithView(Constants.NoSuchUserName);
			}
			this.PackagesService.CreatePackage(model);
			return this.RedirectToHome();
		}

		[Authorize]
		public IActionResult Details(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				//return this.BadRequestError(Constants.NoSuchPackageId);
			}

			return this.View(package);
		}

		[Authorize(Roles="Admin")]
		public IActionResult Pending()
		{
			var packages =
				this.PackagesService.GetAllPendingPackages();
			var model = new PackagesListViewModel{Packages=packages};
			return this.View(model);
		}
		[Authorize(Roles="Admin")]
		public IActionResult Shipped()
		{
			var packages =
				this.PackagesService.GetAllShippedPackages();
			var model = new PackagesListViewModel{Packages=packages};
			return this.View(model);
		}
		[Authorize(Roles="Admin")]
		public IActionResult Delivered()
		{
			var packages =
				this.PackagesService.GetAllDeliveredPackages();
			var model = new PackagesListViewModel{Packages=packages};
			return this.View(model);
		}
		[Authorize(Roles="Admin")]
		public IActionResult Ship(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				//return this.BadRequestError(Constants.NoSuchPackageId);
			}
			this.PackagesService.Ship(id);
			return this.Redirect("/Packages/Pending");
		}
		[Authorize(Roles="Admin")]
		public IActionResult Deliver(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				//return this.BadRequestError(Constants.NoSuchPackageId);
			}
			this.PackagesService.Deliver(id);
			return this.Redirect("/Packages/Shipped");
		}
		[Authorize]
		public IActionResult Acquire(int id)
		{
			var package = this.PackagesService.GetPackage(id);
			if (package == null)
			{
				//return this.BadRequestError(Constants.NoSuchPackageId);
			}

			if (package.Recipient != this.User.Identity.Name)
			{
				//return this.BadRequestError(Constants.InvalidAcquiredMessage);
			}

			this.PackagesService.Acquire(id,this.User.Identity.Name);
			return this.RedirectToHome();
		}
	}
}
