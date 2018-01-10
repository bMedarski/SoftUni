using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PetClinic.Models;

namespace PetClinic.DataProcessor.Dto.Import
{
    public class PassportDto
    {
	    [StringLength(10)]
	    [RegularExpression(@"^[a-zA-Z]{7}[0-9]{3}$")]
	    public string SerialNumber { get; set; }

	    [Required]
	    [RegularExpression(@"(0{1}[0-9]{9}|\+359[0-9]{9})")]
	    public string OwnerPhoneNumber { get; set; }

	    [Required]
	    [MinLength(3)]
	    [MaxLength(30)]
	    public string OwnerName { get; set; }

	    [Required]
	    public string RegistrationDate { get; set; }
	}
}
