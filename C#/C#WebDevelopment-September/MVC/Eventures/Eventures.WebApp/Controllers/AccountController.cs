namespace Eventures.WebApp.Controllers
{
	using System.Security.Claims;
	using System.Threading.Tasks;
	using EventuresModel;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.AccountServices.Contracts;
	using Utilities;
	using ViewModels.Account;

	public class AccountController : Controller
    {
	    public IAccountService AccountsService { get; set; }
	    private SignInManager<EventuresUser> SignInManager { get; }

	    public AccountController(IAccountService accountsService, SignInManager<EventuresUser> signInManager)
	    {
		    this.AccountsService = accountsService;
		    this.SignInManager = signInManager;
	    }

        public IActionResult Login()
        {
            return this.View();
        }

	    [HttpPost]
	    public async Task<IActionResult> Login(LoginViewModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
			    var result = await this.SignInManager.PasswordSignInAsync(model.UserName,
				    model.Password, false, false);

			    if (result.Succeeded)
			    {
				    return this.RedirectToAction("Index", "Home");
			    }
		    }

		    return this.View();
	    }

		[HttpPost]
	    public IActionResult ExternalLogin(string provider, string returnUrl = null)
		{
			var redirectUrl = "/Account/ExternalLogin";
			var properties = this.SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return  new ChallengeResult(provider, properties);
		}

	    public IActionResult ExternalLogin()
	    {
		    var info = this.SignInManager.GetExternalLoginInfoAsync().GetAwaiter().GetResult();
		    var email = info.Principal.FindFirstValue(ClaimTypes.Name);
		    this.AccountsService.CreateUserExternal(email, info);
		    return this.RedirectToAction("Index", "Home");
	    }


	    public IActionResult Register()
	    {
		    return this.View();
	    }
	    [HttpPost]
	    public IActionResult Register(RegisterViewModel model)
	    {
		    if (this.ModelState.IsValid)
		    {
			    this.AccountsService.CreateUser(model);
			    return this.RedirectToAction("Index", "Home");
		    }
		    return this.View(model);
	    }
	    public IActionResult Logout()
	    {
		    this.AccountsService.LogoutUser();
		    return this.RedirectToAction("Index", "Home");
	    }

		[Authorize(Roles = GlobalConstants.AdminRoleText)]
	    public IActionResult AdminPanel()
		{
			var users = new AdminPanelUsersListViewModel{Users = this.AccountsService.AdminPanelUsers()};
			return this.View(users);
		}
	    [Authorize(Roles = GlobalConstants.AdminRoleText)]
	    public IActionResult Demote(string id)
	    {
		    this.AccountsService.Demote(id);
		    return this.RedirectToAction("AdminPanel");
	    }
	    [Authorize(Roles = GlobalConstants.AdminRoleText)]
	    public IActionResult Promote(string id)
	    {
		    this.AccountsService.Promote(id);
		    return this.RedirectToAction("AdminPanel");
	    }
    }
}