namespace AirportModels
{
	using System.Collections.Generic;

	public class User
	{
		public User()
		{
			this.Tickets = new HashSet<Ticket>();
			this.Cart = new HashSet<Ticket>();
		}
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public ICollection<Ticket> Tickets { get; set; }
		public ICollection<Ticket> Cart { get; set; }
		public Role Role { get; set; }
	}
}
