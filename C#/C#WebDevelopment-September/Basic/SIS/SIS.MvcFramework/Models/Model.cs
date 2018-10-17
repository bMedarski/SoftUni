namespace SIS.MvcFramework.Models
{
	public class Model
	{
		private bool? isValid;

		public bool? IsValid
		{
			get => this.isValid;
			set => this.isValid = this.IsValid ?? value;
		}
	}
}
