namespace AirportModels
{
	public class Ticket
	{
		public int Id { get; set; }
		public decimal Price { get; set; }
		public int CustomerId { get; set; }
		public User Customer { get; set; }
		public string Class { get; set; }
		public int FlightId { get; set; }
		public Flight Flight { get; set; }
	}
}
