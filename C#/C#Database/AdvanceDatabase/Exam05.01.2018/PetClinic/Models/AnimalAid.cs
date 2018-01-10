using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PetClinic.Models
{
    public class AnimalAid
    {
	    public AnimalAid()
	    {
		    this.AnimalAidProcedures = new List<ProcedureAnimalAid>();
	    }
		[Required]
		public int Id { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(30)]
		public string Name { get; set; }

	    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
		public decimal Price { get; set; }

		public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; }
	}
}
