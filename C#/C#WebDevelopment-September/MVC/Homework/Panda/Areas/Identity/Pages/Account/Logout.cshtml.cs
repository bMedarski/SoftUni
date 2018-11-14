using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Panda.Data;

namespace Panda.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class LogoutModel : PageModel
	{
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<LogoutModel> _logger;

		public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger)
		{
			this._signInManager = signInManager;
			this._logger = logger;
		}

		public async Task<IActionResult> OnGet()
		{
			await this._signInManager.SignOutAsync();
			this._logger.LogInformation("User logged out.");

			return this.LocalRedirect("/Home/Index");

		}
		public async Task<IActionResult> OnPost(string returnUrl = "/Home/Index")
		{
			await this._signInManager.SignOutAsync();
			this._logger.LogInformation("User logged out.");
			if (returnUrl != null)
			{
				return this.LocalRedirect(returnUrl);
			}
			else
			{
				return this.Page();
			}
		}
	}
}