namespace Eventures.WebApp.Controllers
{
	using Data.Migrations;
	using EventuresModel;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.OrdersServices.Contracts;
	using ViewModels.Orders;

	public class OrdersController : Controller
	{
		private readonly IOrdersService ordersService;
		private readonly UserManager<EventuresUser> userManager;

		public OrdersController(IOrdersService ordersService,UserManager<EventuresUser> userManager)
		{
			this.ordersService = ordersService;
			this.userManager = userManager;
		}

        public IActionResult All()
        {
	        var model = new OrdersListViewModel{Orders = this.ordersService.All()};
	        return this.View(model);
        }

	    public IActionResult Order(OrderBindingModel model)
	    {

		    if (this.ModelState.IsValid)
		    {
			    var user = this.userManager.GetUserAsync(this.User).Result;
			    this.ordersService.Order(model,user);
		    }
		    return this.RedirectToAction("All", "Events",model);
	    }
    }
}