using System;
using System.ComponentModel.DataAnnotations;


namespace PetClinic.DataProcessor.Dto.Import
{
    public class AnimalDto
    {
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

	    public PassportDto Passport { get; set; }
	}
}
