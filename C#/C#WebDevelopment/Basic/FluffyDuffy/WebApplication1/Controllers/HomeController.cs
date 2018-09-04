using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluffyDuffy.Data;
using Microsoft.AspNetCore.Mvc;
using FluffyDuffy.Models;

namespace FluffyDuffy.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(FluffyDuffyContext context)
		{
			this.Context = context;
		}

		public FluffyDuffyContext Context { get; private set; }
		public IActionResult Index()
		{

			var cats = Context.Cats.ToList();
			return View(cats);
		}

	}
}
