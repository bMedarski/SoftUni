namespace Eventures.Services.ViewModels.Account
{
	using System.ComponentModel.DataAnnotations;

	public class RegisterViewModel
	{
		[Display(Name = "Username")]
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		[Display(Name = "Confirm password")]
		public string ConfirmPassword { get; set; }
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		[Display(Name = "UCN")]
		public string UniqueCitizenNumber { get; set; }
	}
}
