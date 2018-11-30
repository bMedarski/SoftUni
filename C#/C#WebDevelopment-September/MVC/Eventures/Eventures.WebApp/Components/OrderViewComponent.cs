namespace Eventures.WebApp.Components
{
	using Microsoft.AspNetCore.Mvc;
	using ViewModels.Events;

	public class OrderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(EventViewModel order)
		{
			if (!this.ModelState.IsValid)
			{
				this.TempData["Error"] = "Tickets count must be less then Total tickets count";
			}
			return this.View(order);
		}
	}
}
