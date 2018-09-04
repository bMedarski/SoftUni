using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Controllers
{
    public class MoviesController : Controller
    {

		[HttpGet]
	    public IActionResult Home()
		{
			this.ViewData["Title"] = "mamka ti";
			return this.View();
		}
    }
}
