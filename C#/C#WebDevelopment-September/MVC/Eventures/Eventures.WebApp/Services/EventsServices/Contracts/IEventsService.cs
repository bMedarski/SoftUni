namespace Eventures.WebApp.Services.EventsServices.Contracts
{
	using System.Collections.Generic;
	using ViewModels.Events;

	public interface IEventsService
	{
		void Create(CreateEventViewModel model);
		IList<EventViewModel> All();
		IList<MyEventsViewModel> MyEvents();
	}
}
