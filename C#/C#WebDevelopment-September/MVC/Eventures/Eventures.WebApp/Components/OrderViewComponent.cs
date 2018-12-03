namespace Eventures.WebApp.Components
{
	using Microsoft.AspNetCore.Mvc;
	using ViewModels.Events;

	public class OrderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(EventViewModel order)
		{
			//if (!this.ModelState.IsValid)
			//{

			//	this.TempData[order.Id] = $"Tickets count must be less then Total tickets count {order.Id}";
			//}
			return this.View(order);
		}
	}
}
