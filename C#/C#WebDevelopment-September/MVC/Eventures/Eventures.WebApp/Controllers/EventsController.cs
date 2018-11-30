namespace Eventures.WebApp.Controllers
{
	using Filter;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using Services.EventsServices.Contracts;
	using Utilities;
	using ViewModels.Events;
	using ViewModels.Orders;

	public class EventsController : Controller
	{

		private readonly IEventsService eventsService;
		private readonly ILogger logger;

		public EventsController(IEventsService eventsService,ILogger<EventsController> logger)
		{
			this.logger = logger;
			this.eventsService = eventsService;
		}

		[Authorize]
	    public IActionResult All(OrderBindingModel orderModel)
		{
			var model = new EventsListViewModel{Events = this.eventsService.All()};
		    return this.View(model);
	    }

		[Authorize]
		public IActionResult MyEvents()
		{
			var model = new MyEventsListViewModel{Events = this.eventsService.MyEvents()};
			return this.View(model);
		}
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
	    public IActionResult Create()
	    {
		    return this.View();
	    }

		[HttpPost]
		[Authorize(Roles = GlobalConstants.AdminRoleText)]
		[ServiceFilter(typeof(LogEventActionFilter))]
	    public IActionResult Create(CreateEventViewModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
				this.eventsService.Create(model);
				this.logger.LogInformation($"Event created: {model.Name}");
			    return this.RedirectToAction("All");
		    }
		    return this.View(model);
	    }
    }
}