using System;
using System.ComponentModel.DataAnnotations;

namespace CHUSKA.Models
{
    public class Product
    {
	    [Key]
	    [Required]
		public int Id { get; set; }

	    [Required]
		public string Name { get; set; }

	    [Required]
		public decimal Price { get; set; }

	    public string Description { get; set; }

		[Required]
	    public ProductType Type { get; set; }

    }
}
