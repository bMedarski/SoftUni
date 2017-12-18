using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
	[XmlType("Order")]
	public class OrdersDto
    {
	    [Required]
		public string Name { get; set; }

	    [Required]
		public string Employee { get; set; }

	    [Required]
		public string Datetime { get; set; }

	    [Required]
		public string Type { get; set; }

		public ICollection<ItemOrderDto> Items { get; set; }
    }
}
