namespace SIS.MvcFramework.Attributes.Property
{
	using System.ComponentModel.DataAnnotations;

	public class NumberRangeAttribute:ValidationAttribute
	{
		private readonly double minValue;
		private readonly double maxValue;

		public NumberRangeAttribute(double minValue, double maxValue)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
		}

		public override bool IsValid(object value)
		{
			return this.minValue <= (double) value && (double) value >= this.maxValue;
		}
	}
}
