using System;
using System.IO;
using CHUSKA.Models;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;

namespace CHUSHKA.App.Controllers
{
	public class ProductsController : BaseController
	{

		[HttpGet]
		public IActionResult Details(int id)
		{
			if (!this.User.IsAuthenticated)
			{
				return RedirectToLogin();
			}

			var product = this.products.GetById(id);

			this.ViewData.Data["productPrice"] = product.Price.ToString();
			this.ViewData.Data["productName"] = product.Name;
			this.ViewData.Data["productDescription"] = product.Description;
			this.ViewData.Data["productType"] = product.Type;
			this.ViewData.Data["productId"] = product.Id.ToString();
			var userHome = File.ReadAllText("./Views/Partials/registered_user-nav.html");
			this.ViewData["nav"] = userHome;

			if (this.User.IsInRole("Admin"))
			{
				var adminOrderView = File.ReadAllText("./Views/Partials/orderAdminView.html");
				this.ViewData["orderAdminView"] = adminOrderView;
			}


			return View();
		}

		[HttpGet]
		public IActionResult Order(int id)
		{

			Console.WriteLine();
			var product = Db.Products.Find(id);

			var order = new Order
			{
				Id = Guid.NewGuid().ToString(),
				ClientId = this.User.Id,
				OrderedOn = DateTime.Now,
				Product = product
			};

			Db.Orders.Add(order);
			Db.SaveChanges();

			return this.RedirectToHome();
		}
	}
}
