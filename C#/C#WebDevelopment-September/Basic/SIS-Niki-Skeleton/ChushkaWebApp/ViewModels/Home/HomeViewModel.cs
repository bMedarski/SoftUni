namespace ChushkaWebApp.ViewModels.Home
{
	using System.Collections.Generic;
	using Products;

	public class HomeViewModel
	{
		public IEnumerable<ProductsHomeViewModel> Products;
		public int EmptyBlocks { get; set; } = 0;
	}
}
