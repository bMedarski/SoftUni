namespace Eventures.WebApp.Services.EventsServices
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	using Contracts;
	using Data;
	using EventuresModel;
	using ViewModels.Events;

	public class EventsService:IEventsService
	{
		private EventuresDbContext dbContext;
		private IMapper autoMapper;

		public EventsService(EventuresDbContext dbContext,IMapper autoMapper)
		{
			this.autoMapper = autoMapper;
			this.dbContext = dbContext;
		}

		public IList<EventViewModel> All()
		{
			return this.dbContext.EventuresEvents.Where(e => e.TotalTickets > 0).OrderByDescending(e => e.Start)
				.Select(e => this.autoMapper.Map<EventViewModel>(e)).ToList();
		}

		public IList<MyEventsViewModel> MyEvents()
		{
			var events = this.dbContext.EventuresEvents.Where(e => e.TotalTickets > 0).OrderByDescending(e => e.Start)
				.Select(e => this.autoMapper.Map<MyEventsViewModel>(e)).ToList();

			return events;
		}

		public void Create(CreateEventViewModel model)
		{
			var eventureEvent = this.autoMapper.Map<EventuresEvent>(model);
			this.dbContext.Add(eventureEvent);
			this.dbContext.SaveChanges();
		}
	}
}
