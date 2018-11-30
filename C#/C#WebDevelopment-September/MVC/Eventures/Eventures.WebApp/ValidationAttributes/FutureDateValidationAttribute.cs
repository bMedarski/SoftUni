namespace Eventures.WebApp.ValidationAttributes
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class FutureDateValidationAttribute:ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime dateJoin = Convert.ToDateTime(value);
			if (dateJoin >= DateTime.Now)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult(this.ErrorMessage);
			}
		}
	}
}
