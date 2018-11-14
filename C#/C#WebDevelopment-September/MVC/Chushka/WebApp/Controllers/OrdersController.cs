namespace WebApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Contracts;
	using Utilities;
	using ViewModels.Orders;

	public class OrdersController : Controller
    {
	    public IOrdersService OrdersService { get; set; }

	    public OrdersController(IOrdersService ordersService)
	    {
		    this.OrdersService = ordersService;
	    }

		[Authorize(Roles = GlobalConstants.AdminRoleText)]
        public IActionResult All()
		{
			var orders = this.OrdersService.GetAllOrders();
			var model = new OrdersListViewModel {Orders = orders};
            return this.View(model);
        }

    }
}