using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.WebApp.ValidationAttributes
{
	public class DateGreaterThan : ValidationAttribute
	{
		private readonly string _startDatePropertyName;
		public DateGreaterThan(string startDatePropertyName)
		{
			this._startDatePropertyName = startDatePropertyName;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var propertyInfo = validationContext.ObjectType.GetProperty(this._startDatePropertyName);
			var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
			if ((DateTime)value > (DateTime)propertyValue)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult("Start date must be before end date");
			}
		}
	}
}