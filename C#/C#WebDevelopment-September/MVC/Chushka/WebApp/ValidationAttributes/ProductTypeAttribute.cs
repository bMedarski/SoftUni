namespace WebApp.ValidationAttributes
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using global::Models.Enums;

	public class ProductTypeAttribute:ValidationAttribute
	{
		protected override ValidationResult IsValid(object productType, ValidationContext validationContext)
		{
			if (productType == null)
			{
				return new ValidationResult("The product type is invalid.");
			}
			if (Enum.IsDefined(typeof(ProductType), productType))
			{
				return ValidationResult.Success;
			}
			return new ValidationResult("The product type is invalid.");
		}
	}
}
