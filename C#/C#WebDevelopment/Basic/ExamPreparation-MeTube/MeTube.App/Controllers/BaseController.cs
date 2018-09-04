namespace MeTube.App.Controllers
{
    using System.Linq;
    using SimpleMvc.Data;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new MeTubeDbContext();
            this.Model["anonymousDisplay"] = "flex";
            this.Model["displayAddNote"] = "none";
            this.Model["alertDisplay"] = "none";
            this.Model.Data["show-error"] = "none";

        }

        protected MeTubeDbContext Db { get; private set; }

        protected void ShowError(string error)
        {
            this.Model.Data["show-error"] = "block";
            this.Model.Data["error"] = error;
        }

        protected void ShowAlert(string alert)
        {
            this.Model.Data["alertDisplay"] = "block";
            this.Model.Data["alertMessage"] = alert;
        }

        protected void GetUserIdForNavBar()
        {
            if (this.User != null && this.User.IsAuthenticated)
            {
                int? userId = this.Db
                    .Users
                    .FirstOrDefault(u => u.Username == this.User.Name).Id;

                if (userId != null)
                {
                    this.Model["id"] = userId.ToString();
                }
            }

        }
        protected IActionResult RedirectToHome()
        {
            return this.RedirectToAction("/home/index");
        }

        protected IActionResult RedirectToLogin()
        {
            return this.RedirectToAction("/users/login");
        }

    }
}
