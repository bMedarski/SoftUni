namespace ChushkaWebApp.Controllers
{
	using ChushkaData;
	using Common;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Products;

	public class ProductsController:BaseController
	{
		private ProductsService ProductsService { get; set; }

		public ProductsController(ChushkaDb db,ProductsService productsService)
		:base(db)
		{
			this.ProductsService = productsService;
		}

		[Authorize]
		public IHttpResponse All()
		{
			return this.View();
		}

		[Authorize]
		public IHttpResponse Details(int id)
		{
			var model = this.ProductsService.GetProduct(id);
			if (model == null)
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			return this.View(model);
		}

		[Authorize("Admin")]
		public IHttpResponse Create()
		{
			return this.View();
		}

		[Authorize("Admin")]
		[HttpPost]
		public IHttpResponse Create(ProductCreateViewModel model)
		{
			this.ProductsService.CreateProduct(model);
			return this.RedirectToHome();
		}

		[Authorize("Admin")]
		public IHttpResponse Delete(int id)
		{
			var model = this.ProductsService.GetProduct(id);
			if (model == null)
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			return this.View(model);
		}	

		[Authorize("Admin")]
		[HttpPost]
		public IHttpResponse Delete(ProductViewModel model)
		{
			var product = this.ProductsService.GetProduct(model.Id);
			if (product == null)
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			this.ProductsService.DeleteProduct(product.Id);

			return this.RedirectToHome();
		}	
		
		[Authorize("Admin")]
		public IHttpResponse Edit(int id)
		{
			var model = this.ProductsService.GetProduct(id);
			if (model == null)
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			return this.View(model);
		}

		[Authorize("Admin")]
		[HttpPost]
		public IHttpResponse Edit(ProductViewModel model)
		{
			var product = this.ProductsService.GetProduct(model.Id);
			if (product == null)
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}

			this.ProductsService.EditProduct(model);

			return this.RedirectToHome();
		}

		[Authorize]
		public IHttpResponse Order(int id)
		{
			var user = this.User.Username;
			var model = this.ProductsService.GetProduct(id);
			if (model == null)
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			this.ProductsService.OrderProduct(id,user);
			return this.RedirectToHome();
		}
	}
}
