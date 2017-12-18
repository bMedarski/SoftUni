using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
	[XmlType("Item")]
	public class ItemOrderDto
    {
	    [Required]
	    [MinLength(3)]
	    [MaxLength(30)]
		public string Name { get; set; }
		public int Quantity { get; set; }
    }
}
