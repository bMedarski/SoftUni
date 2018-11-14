namespace WebApp.ViewModels.Account
{
	using System.ComponentModel.DataAnnotations;

	public class RegisterViewModel
	{
		[Required]
		[DataType(DataType.Text)]
		public string Username { get; set; }
		[Required]
		[Display(Name = "Email Address")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
		[Required]
		[DataType(DataType.Text)]
		public string FullName { get; set; }
	}
}
