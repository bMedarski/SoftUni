namespace WebApp.Services.Contracts
{
	using System.Collections.Generic;
	using System.Security.Claims;
	using global::Models;
	using ViewModels.Home;
	using ViewModels.Products;

	public interface IProductsService
	{
		Product Create(ProductViewModel model);
		IList<HomeProductViewModel> GetAllProducts();
		ProductDetailsViewModel GetProductDetails(int id);
		ProductViewModel GetProductViewModel(int id);
		void Edit(ProductViewModel model);
		void Delete(ProductViewModel model);
		void Order(int id, ClaimsPrincipal userPrincipal);
	}
}
