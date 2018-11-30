namespace Eventures.WebApp.ViewModels.Account
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Authentication;

	public class LoginViewModel
	{
		[Display(Name = "Username")]
		public string UserName { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string ReturnUrl { get; set; } = "/";
	}
}
