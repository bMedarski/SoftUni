namespace AirportModels
{
	using System;
	using System.Collections.Generic;

	public class Flight
	{
		public Flight()
		{
			this.Tickets = new List<Ticket>();
		}
		public int Id { get; set; }
		public string Destination { get; set; }
		public string Origin { get; set; }
		public DateTime Date { get; set; }
		public string Time { get; set; }
		public string ImageUrl { get; set; }
		public bool Public { get; set; }
		public ICollection<Ticket> Tickets { get; set; }
	}
}
