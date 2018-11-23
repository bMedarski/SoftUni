namespace WebApp.ViewModels.Products
{
	using System.ComponentModel.DataAnnotations;
	using ValidationAttributes;

	public class ProductViewModel
	{

		public int Id { get; set; } = 0;

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		[Range(typeof(decimal),"0","99")]
		public decimal Price { get; set; }

		[Required]
		[Display(Name = "Product Type")]
		[ProductType]
		public string Type { get; set; }

	}
}