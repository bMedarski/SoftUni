using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Passport
    {
	    [StringLength(10)]
	    [RegularExpression(@"^[a-zA-Z]{7}[0-9]{3}$")]
		public string SerialNumber { get; set; }

		public int AnimalId { get; set; }
		[Required]
	    public Animal Animal { get; set; }

	    [Required]
	    [RegularExpression(@"(0{1}[0-9]{9}|\+359[0-9]{9})")]
		public string OwnerPhoneNumber { get; set; }

		[Required]
	    [MinLength(3)]
	    [MaxLength(30)]
		public string OwnerName { get; set; }

	    [Required]
		public DateTime RegistrationDate  { get; set; }
	}
}
