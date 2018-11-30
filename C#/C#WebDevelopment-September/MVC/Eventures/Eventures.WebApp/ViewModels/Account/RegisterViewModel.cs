namespace Eventures.WebApp.ViewModels.Account
{
	using System.ComponentModel.DataAnnotations;

	public class RegisterViewModel
	{
		[Display(Name = "Username")]
		[MinLength(3)]
		[RegularExpression("[a-zA-Z0-9-*_~.]+")]
		public string UserName { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[MinLength(5)]
		public string Password { get; set; }

		[Display(Name = "Confirm password")]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "UCN")]
		[RegularExpression("[0-9]{10}")]
		public int UniqueCitizenNumber { get; set; }
	}
}
