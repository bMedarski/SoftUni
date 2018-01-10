using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Procedure
    {
	    public Procedure()
	    {
		    this.ProcedureAnimalAids = new List<ProcedureAnimalAid>();
	    }
		public int Id { get; set; }

		public int AnimalId { get; set; }
		[Required]
		public Animal Animal { get; set; }

		public int VetId { get; set; }
		[Required]
		public Vet Vet { get; set; }

		public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }

	    [NotMapped]
	    public decimal Cost { get; set; }    //=> this.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity);

		public DateTime DateTime { get; set; }
	}
}
