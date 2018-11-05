namespace PandaWebApp.Models.BindingModels.Users
{
	public class RegisterBindingModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Email { get; set; }
	}
}
