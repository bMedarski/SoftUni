namespace GameStore.Controllers
{
	using System;
	using System.Linq;
	using Common;
	using Microsoft.EntityFrameworkCore;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels;

	public class UsersController : BaseController
	{
		private readonly UsersService usersService;
		private readonly GameService gameService;

		public UsersController(UsersService usersService, GameService gameService)
		{
			this.usersService = usersService;
			this.gameService = gameService;
		}
		[Authorize]
		public IHttpResponse Cart()
		{
			var userId = this.Db.Users.Where(u => u.Email == this.User.Username).Select(u => u.Id).FirstOrDefault();
			var games = this.Db.Games
				.Include(g => g.Carts)
				.ThenInclude(gc => gc.Cart.Games)
				.Select(g =>
				new GameViewModel
				{
					Id = g.Id,
					Title = g.Title,
					Description = g.Description.Substring(0, 300),
					Size = g.Size,
					Price = g.Price,
					Trailer = g.Trailer,
					Thumbnail = g.Thumbnail,
					ReleaseDate = g.ReleaseDate,
					UserId = g.Carts.Select(c => c.Cart.UserId).FirstOrDefault()
				})
				.Where(g => g.UserId == userId)
				.ToList();

			var myGames = new HomeViewModel
			{
				Games = games,
			};
			return this.View(myGames);
		}
		[Authorize]
		public IHttpResponse Logout()
		{
			this.SignOff();
			return this.RedirectToHome();
		}

		public IHttpResponse Login()
		{
			return this.View();
		}

		[HttpPost]
		public IHttpResponse Login(LoginInputViewModel model)
		{
			var user = this.usersService.GetUserByUsernameAndPassword(model.Email, model.Password);

			if (user == null)
			{
				return this.BadRequestErrorWithView(Constants.WrongUserNameOrPassword);
			}
			this.SignIn(user);
			return this.RedirectToHome();
		}
		public IHttpResponse Register()
		{
			return this.View();
		}

		[HttpPost]
		public IHttpResponse Register(RegisterInputViewModel model)
		{
			var validation = this.ValidateUser(model);
			if (validation != "")
			{
				return this.BadRequestErrorWithView(validation);
			};
			if (this.usersService.GetUserByUsernameAndPassword(model.Email, model.Password) != null)
			{
				return this.BadRequestErrorWithView(Constants.DuplicateUserIdMessage);
			}
			var user = this.usersService.CreateUser(model);
			this.SignIn(user);
			return this.RedirectToHome();
		}
		[Authorize]
		public IHttpResponse Buy(int id)
		{
			var game = this.gameService.GetGameById(id);
			if (game == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchIdMessage);
			}

			var user = this.usersService.GetUserByUsername(this.User.Username);

			foreach (var userGame in user.Games)
			{
				if (userGame.Game.Id == game.Id)
				{
					return this.BadRequestError(Constants.DuplicateGameInShoppingCart);
				}
			}
			foreach (var userGame in user.Cart.Games)
			{
				if (userGame.Game.Id == game.Id)
				{
					return this.BadRequestError(Constants.DuplicateGameInShoppingCart);
				}
			}

			this.usersService.BuyGame(game, user);
			return this.RedirectToHome();
		}
		private string ValidateUser(RegisterInputViewModel model)
		{
			if (!Validator.IfContainsSymbol(model.Email, Constants.EmailRequiredCharacter))
			{
				return Constants.InvalidEmailMessage;
			}

			if (!Validator.DoesMatchPattern(model.Fullname, Constants.LoginValidationNamePattern))
			{
				return Constants.InvalidFullNameMessage;
			}
			if (!Validator.DoesMatchPattern(model.Password, Constants.LoginValidationPasswordPattern))
			{
				return Constants.InvalidPasswordMessage;
			}

			if (!Validator.AreTheSame(model.Password, model.ConfirmPassword))
			{
				return Constants.InvalidRepeatPasswordMessage;
			}

			return "";
		}
	}
}
