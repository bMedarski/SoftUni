using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dto.Import
{
	[XmlType("AnimalAid")]
	public class AnimalAidXmlDto
    {
	    [Required]
	    [MinLength(3)]
	    [MaxLength(30)]
	    public string Name { get; set; }
	}
}
