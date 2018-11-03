namespace ChushkaWebApp.Controllers
{
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Orders;

	public class OrdersController:Controller
	{
		private OrdersService OrdersService { get; set; }

		public OrdersController(OrdersService ordersService)
		{
			this.OrdersService = ordersService;
		}

		[Authorize("Admin")]
		public IHttpResponse All()
		{
			var model = new OrdersListViewModel {Orders = this.OrdersService.GetAllOrders()};
			return this.View(model);
		}
	}
}
