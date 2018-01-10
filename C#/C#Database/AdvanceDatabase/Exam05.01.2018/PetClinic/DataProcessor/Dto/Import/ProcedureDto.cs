
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dto.Import
{
	[XmlType("Procedure")]
	public class ProcedureDto
    {
	    [Required]
	    public string Animal { get; set; }
	    [Required]
	    public string Vet { get; set; }
	    public string DateTime { get; set; }


		public AnimalAidXmlDto[] AnimalAids { get; set; } = new AnimalAidXmlDto[0];
	}
}
