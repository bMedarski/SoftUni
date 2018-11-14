namespace WebApp.Controllers
{
	using System.Diagnostics;
	using Microsoft.AspNetCore.Mvc;
	using Models;
	using Services.Contracts;
	using ViewModels.Home;

	public class HomeController : Controller
	{

		public IProductsService ProductsService { get; set; }

		public HomeController(IProductsService productsService)
		{
			this.ProductsService = productsService;
		}

		public IActionResult Index()
		{
			if (this.User.Identity.IsAuthenticated)
			{
				var products = new HomeProductListViewModel {Products = this.ProductsService.GetAllProducts()};
				return this.View(products);
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
