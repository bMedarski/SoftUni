namespace ChushkaModels
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int ProductTypeId { get; set; }
		public ProductType ProductType { get; set; }
	}
}
