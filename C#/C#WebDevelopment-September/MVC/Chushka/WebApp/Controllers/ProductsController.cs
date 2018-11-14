namespace WebApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Contracts;
	using Utilities;
	using ViewModels.Products;

	public class ProductsController : Controller
	{
		public IProductsService ProductsService { get; set; }

		public ProductsController(IProductsService productsService)
		{
			this.ProductsService = productsService;
		}

		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		public IActionResult Create()
		{
			return this.View();
		}
		[HttpPost]
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		public IActionResult Create(ProductViewModel model)
		{
			if (this.ModelState.IsValid)
			{
				var product = this.ProductsService.Create(model);
				if (product != null)
				{
					return this.RedirectToAction("Index", "Home");
				}
				return this.View(model);
			}
			return this.View(model);
		}
		[Authorize]
		public IActionResult Details(int id)
		{
			ProductDetailsViewModel product = this.ProductsService.GetProductDetails(id);
			return this.View(product);
		}
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		public IActionResult Edit(int id)
		{
			ProductViewModel product = this.ProductsService.GetProductViewModel(id);
			return this.View(product);
		}
		[HttpPost]
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		public IActionResult Edit(ProductViewModel model)
		{
			if (this.ModelState.IsValid)
			{
				this.ProductsService.Edit(model);
			}
			else
			{
				return this.View(model);
			}

			return this.RedirectToAction("Index", "Home");
		}
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		public IActionResult Delete(int id)
		{
			ProductViewModel product = this.ProductsService.GetProductViewModel(id);
			return this.View(product);
		}
		[HttpPost]
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		public IActionResult Delete(ProductViewModel model)
		{
			this.ProductsService.Delete(model);
			return this.RedirectToAction("Index", "Home");
		}
		[Authorize]
		public IActionResult Order(int id)
		{
			var user = this.User;
			this.ProductsService.Order(id,user);
			return this.RedirectToAction("Index", "Home");
		}
	}
}