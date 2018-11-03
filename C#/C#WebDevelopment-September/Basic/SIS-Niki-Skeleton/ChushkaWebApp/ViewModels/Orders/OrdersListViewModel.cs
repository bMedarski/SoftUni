namespace ChushkaWebApp.ViewModels.Orders
{
	using System.Collections.Generic;

	public class OrdersListViewModel
	{
		public IEnumerable<OrdersViewModel> Orders { get; set; }
	}
}
