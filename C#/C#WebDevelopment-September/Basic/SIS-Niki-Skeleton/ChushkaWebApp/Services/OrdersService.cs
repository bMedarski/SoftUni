namespace ChushkaWebApp.Services
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using ChushkaData;
	using Common;
	using ViewModels.Orders;

	public class OrdersService
	{
		public ChushkaDb Db { get; set; }

		public OrdersService(ChushkaDb db)
		{
			this.Db = db;
		}

		internal List<OrdersViewModel> GetAllOrders()
		{
			return this.Db.Orders.Select(o => new OrdersViewModel
			{
				Id = o.Id,
				Customer = o.Client.Username,
				Product = o.Product.Name,
				OrderedOn = o.OrderedOn.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture),
			}).ToList();
		}
	}
}
