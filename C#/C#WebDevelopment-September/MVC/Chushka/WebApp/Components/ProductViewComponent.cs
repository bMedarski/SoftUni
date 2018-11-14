namespace WebApp.Components
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
	using ViewModels.Home;

	public class ProductViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke(ICollection<HomeProductViewModel> products)
		{
			var model = new HomeProductListViewModel{Products = products};
			return this.View<HomeProductListViewModel>(model);
		}
	}
}
