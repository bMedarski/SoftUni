namespace ChushkaWebApp.Controllers
{
	using System.Collections.Generic;
	using ChushkaData;
	using Services;
	using SIS.HTTP.Responses;
	using ViewModels.Home;
	using ViewModels.Products;

	public class HomeController:BaseController
	{
		private ProductsService ProductsService { get; set; }

		public HomeController(ChushkaDb db,ProductsService productsService)
		:base(db)
		{
			this.ProductsService = productsService;
		}

		public IHttpResponse Index()
		{
			if (this.User.IsLoggedIn)
			{
				var products = this.ProductsService.GetAllProducts();
				var productsCount = products.Count;
				foreach (var product in products)
				{
					if (product.Description.Length > 50)
					{
						product.Description = product.Description.Substring(0,50) + "...";
					}
				}
				var model = new HomeViewModel {Products = products};
				if (productsCount % 5 != 0 && productsCount % 5 < 5)
				{
					model.EmptyBlocks = 5 - (productsCount % 5);
				}
				return this.View(model);
			}

			var emptyModel = new HomeViewModel() {Products = new List<ProductsHomeViewModel>(), EmptyBlocks = 0};
			return this.View(emptyModel);
		}
	}
}
