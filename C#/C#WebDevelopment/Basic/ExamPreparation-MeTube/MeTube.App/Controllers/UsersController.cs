namespace MeTube.App.Controllers
{
    using System.Linq;
    using System.Text;
    using Models;
    using Services;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class UsersController : BaseController
    {
        public const string RegisterErrorMessage = @"<p>Check your form for errors.</p><p> Username must be between 3 and 50 symbols.</p><p>Passwords must be between 4 and 30 symbols.</p><p>Confirm password must match the provided password.</p>";
        public const string ConfirmPasswordError = @"<p>Confirm password must match the provided password.</p>";
        public const string LoginErrorMessage = @"<p>Invalid User Credentials!</p>";
        public const string UnsuccessfulRegister = @"<p>Unsuccessful Register!</p>";

        private readonly UsersService users;
        private readonly TubesService tubes;

        public UsersController()
        {
            this.users = new UsersService();
            this.tubes = new TubesService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }
            if (!IsValidModel(model))
            {
                ShowError(RegisterErrorMessage);
                return View();
            }
            if (model.Password != model.ConfirmPassword)
            {
                ShowError(ConfirmPasswordError);
                return View();
            }
            var successRegister = this.users.Create(model.Username, model.Password, model.Email);

            if (!successRegister)
            {
                ShowError(UnsuccessfulRegister);
                return View();
            }

            SignIn(model.Username);
            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }
            if (!IsValidModel(model))
            {
                ShowError(LoginErrorMessage);
                return View();
            }

            
            var userExist = this.users.UserExists(model.Username, model.Password);
            if (userExist == null)
            {
                ShowError(LoginErrorMessage);
                return View();
            }

            SignIn(model.Username);
            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }

            var email = this.users.GetByName(this.User.Name).Email;
            var tubes = this.tubes.AllByUser(id);
            var builder = new StringBuilder();

            foreach (var tube in tubes)
            {
                builder.AppendLine($@"
<tr>
    <td>#</td>
    <td><small>{tube.Id}</small></td>
    <td><small>{tube.Title}</small></td>
    <td><small>{tube.Author}</small></td>
    <td>
    <a href=""/tubes/details?id={tube.Id}"">Details</a>
    </td>
 </tr>");
            }

            this.Model["username"] = this.User.Name;
            this.Model["useremail"] = email;
            this.Model["tubes"] = builder.ToString();
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            SignOut();

            return RedirectToAction("/home/index");
        }
    }
}
