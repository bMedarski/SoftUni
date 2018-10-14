using FluffyDuffy.Data;
using Microsoft.AspNetCore.Mvc;

namespace FluffyDuffy.Controllers
{
	public class CatsController : Controller
    {
	    public CatsController(FluffyDuffyContext dbContext)
	    {
		    this.DbContext = dbContext;
	    }

	    public FluffyDuffyContext DbContext { get; set; }
	    public IActionResult Details(int id)
	    {
		    var cat = DbContext.Cats.Find(id);
		    return this.View(cat);
	    }

    }
}
