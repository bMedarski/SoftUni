namespace WebApp.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Data;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Orders;

	public class OrdersService:IOrdersService
	{
		public ChushkaDbContext DbContext { get; set; }

		public OrdersService(ChushkaDbContext dbContext)
		{
			this.DbContext = dbContext;
		}

		public IList<OrdersViewModel> GetAllOrders()
		{
			return this.DbContext.Orders
				.Include(o => o.Product)
				.Include(o => o.Client)
				.Select(o => new OrdersViewModel()
				{
					Id = o.Id,
					Customer = o.Client.UserName,
					Product = o.Product.Name,
					OrderedOn = o.OrderedOn,
				})
				.ToList();
		}
	}
}
