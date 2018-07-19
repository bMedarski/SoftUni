using System;
using System.ComponentModel.DataAnnotations;

namespace CHUSKA.Models
{
    public class Order
    {
		[Key]
		[Required]		
	    public string Id { get; set; }

		public Product Product { get; set; }

		[Required]
	    public int ClientId { get; set; }

	    [Required]
		public User Client { get; set; }

	    public DateTime OrderedOn { get; set; }

    }
}
