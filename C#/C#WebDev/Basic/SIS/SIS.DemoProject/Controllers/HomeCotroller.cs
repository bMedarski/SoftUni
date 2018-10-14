namespace SIS.DemoProject.Controllers
{
	using MvcFramework.ActionResults.Contracts;
	using MvcFramework.Controllers;

	public class HomeController:Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
	}
}
