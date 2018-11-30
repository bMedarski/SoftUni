namespace Eventures.WebApp.Services.OrdersServices
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	using Contracts;
	using Data;
	using EventuresModel;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Orders;

	public class OrdersService : IOrdersService
	{
		private readonly EventuresDbContext dbContext;
		private IMapper autoMapper;

		public OrdersService(EventuresDbContext dbContext,IMapper autoMapper)
		{
			this.autoMapper = autoMapper;
			this.dbContext = dbContext;
		}

		public void Order(OrderBindingModel model, EventuresUser user)
		{
			var eventureEvent = this.dbContext.EventuresEvents.SingleOrDefault(e => e.Id == model.Id);
			if (eventureEvent != null)
			{
				var order = new EventuresOrder()
				{
					Customer = user,
					Event = eventureEvent,
					TicketsCount = model.TicketsCount,
					OrderedOn = DateTime.UtcNow
				};
				eventureEvent.TotalTickets -= model.TicketsCount;
				this.dbContext.EventuresOrders.Add(order);
				this.dbContext.SaveChanges();
			}
		}

		public IList<OrdersViewModel> All()
		{
			return this.dbContext.EventuresOrders
				.Include(o=>o.Customer)
				.Include(o=>o.Event)
				.OrderByDescending(o=>o.OrderedOn)
				.Select(o => this.autoMapper.Map<OrdersViewModel>(o))
				.ToList();
		}
	}
}
