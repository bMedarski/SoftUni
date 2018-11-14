namespace WebApp.Services.Contracts
{
	using System.Collections.Generic;
	using ViewModels.Orders;

	public interface IOrdersService
	{
		IList<OrdersViewModel> GetAllOrders();
	}
}
