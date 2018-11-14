namespace Models
{
	using System;

	public class Order
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public string ClientId { get; set; }
		public ChushkaUser Client { get; set; }
		public DateTime OrderedOn { get; set; }
	}
}
