using System.ComponentModel.DataAnnotations;

namespace CHUSKA.Models
{
    public class ProductType
    {
		[Key]
	    [Required]
		public int Id { get; set; }

	    [Required]
		public string Name { get; set; }

    }
}
