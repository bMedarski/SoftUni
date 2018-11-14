namespace WebApp.ViewModels.Account
{
	using System.ComponentModel.DataAnnotations;

	public class LoginViewModel
	{
		[Required]
		[DataType(DataType.Text)]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
