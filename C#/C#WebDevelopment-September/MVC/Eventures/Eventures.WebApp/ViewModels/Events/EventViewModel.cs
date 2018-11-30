namespace Eventures.WebApp.ViewModels.Events
{
	using System;
	public class EventViewModel
	{

		public string Name { get; set; }

		public string Id { get; set; }
		
		public DateTime Start { get; set; }
		
		public DateTime End { get; set; }

		public int TotalTickets { get; set; }
	}
}
