namespace PandaModel
{
	using System;

	public class Package
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public double Weight { get; set; }
		public string ShippingAddress { get; set; }
		public Status Status { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public int RecipientId { get; set; }
		public User Recipient { get; set; }
	}
}
