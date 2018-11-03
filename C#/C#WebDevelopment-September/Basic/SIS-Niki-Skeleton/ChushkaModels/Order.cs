namespace ChushkaModels
{
	using System;

	public class Order
	{
		public string Id { get; set; }
		public User Client { get; set; }
		public int ClientId { get; set; }
		public Product Product { get; set; }
		public int ProductId { get; set; }
		public DateTime OrderedOn { get; set; }

	}
}
