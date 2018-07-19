using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CHUSHKA.App.ViewModels;
using Microsoft.EntityFrameworkCore;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;

namespace CHUSHKA.App.Controllers
{
	public class UsersController : BaseController
	{
		[HttpGet]
		public IActionResult Register()
		{
			if (this.User.IsAuthenticated)
			{
				return RedirectToHome();
			}
			return View();
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
		public IActionResult Register(RegisterViewModel model)
		{
			if (this.User.IsAuthenticated)
			{
				return RedirectToHome();
			}
			if (!IsValidModel(model))
			{
				ShowError("Fill all required");
				return View();
			}
			if (model.Password != model.ConfirmPassword)
			{
				ShowError("Password do not match");
				return View();
			}

			using (Db)
			{
				var successRegister = this.users.Create(model.Username, model.Password, model.Email, model.FullName);

				if (!successRegister)
				{
					ShowError("Unsuccessfull Register");
					return View();
				}

				var user = Db.Users.Include(u=>u.Role).Where(u => u.Username == model.Username).FirstOrDefault();

				var roles = new List<string> {user.Role.ToString()};

				SignIn(model.Username, user.Id, roles);
			}
			return RedirectToHome();
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
				ShowError("Wrong Username or Password");
				return View();
			}


			var userExist = this.users.UserExists(model.Username, model.Password);
			if (userExist == null)
			{
				ShowError("User already exist");
				return View();
			}

			var user = Db.Users.Include(u => u.Role).Where(u => u.Username == model.Username).FirstOrDefault();
			var roles = new List<string> { user.Role.Name };
			SignIn(model.Username, user.Id, roles);

			return RedirectToHome();
		}
		[HttpGet]
		public IActionResult Logout()
		{
			SignOut();

			return RedirectToAction("/home/index");
		}
	}
}
