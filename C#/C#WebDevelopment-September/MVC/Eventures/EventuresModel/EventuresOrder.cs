namespace EventuresModel
{
	using System;

	public class EventuresOrder
	{
		public string Id { get; set; }
		public DateTime OrderedOn { get; set; }
		public EventuresUser Customer { get; set; }
		public EventuresEvent Event { get; set; }
		public int TicketsCount { get; set; }
	}
}
