namespace Eventures.WebApp.Services.OrdersServices.Contracts
{
	using System.Collections.Generic;
	using EventuresModel;
	using ViewModels.Orders;

	public interface IOrdersService
	{
		void Order(OrderBindingModel model, EventuresUser user);
		IList<OrdersViewModel> All();
	}
}
