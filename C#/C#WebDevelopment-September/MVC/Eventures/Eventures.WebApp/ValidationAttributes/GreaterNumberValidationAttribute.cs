using System;

namespace Eventures.WebApp.ValidationAttributes
{
	using System.ComponentModel.DataAnnotations;

	public class GreaterNumberValidationAttribute:ValidationAttribute
	{
		private readonly string tickets;
		public GreaterNumberValidationAttribute(string tickets)
		{
			this.tickets = tickets;
		}
		protected override ValidationResult IsValid(object totalTickets, ValidationContext validationContext)
		{
			var propertyInfo = validationContext.ObjectType.GetProperty(this.tickets);
			var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
			if ((int)totalTickets >= (int)propertyValue)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult("Tickets count bought must be same or less then tickets left");
			}
		}
	}
}
