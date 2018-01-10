using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class Animal
    {
	    public Animal()
	    {
		    this.Procedures = new List<Procedure>();
	    }

	    [Required]   
		public int Id { get; set; }

	    [Required]
		[MinLength(3)]
	    [MaxLength(20)]
	    public string Name { get; set; }

	    [Required]
	    [MinLength(3)]
	    [MaxLength(20)]
		public string Type { get; set; }

	    [Required]
	    [Range(1, Int32.MaxValue)]
		public int Age { get; set; }

		public string PassportSerialNumber { get; set; }
	    [Required]
		public Passport Passport { get; set; }

	    public ICollection<Procedure> Procedures { get; set; }
	}
}
