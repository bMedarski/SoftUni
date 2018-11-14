namespace WebApp.ViewModels.Orders
{
	using System;

	public class OrdersViewModel
	{
		public int Id { get; set; }
		public string Customer { get; set; }
		public string Product { get; set; }
		public DateTime OrderedOn { get; set; }
		public string OrderedOnFormatted => this.OrderedOn.ToString("g");
	}
}
