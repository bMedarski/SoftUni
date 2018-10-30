namespace GameStore.Controllers
{
	using System.Globalization;
	using System.Linq;
	using Common;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels;

	public class GamesController : BaseController
	{
		private readonly GameService gameService;

		public GamesController(GameService gameService)
		{
			this.gameService = gameService;
		}
		[Authorize]
		public IHttpResponse Add()
		{
			return this.View();
		}
		[Authorize]
		[HttpPost]
		public IHttpResponse Add(GameViewModel model)
		{
			var validation = this.ValidateGame(model);
			if (validation != "")
			{
				return this.BadRequestErrorWithView(validation);
			}

			this.gameService.AddGame(model);

			return this.RedirectToHome();
		}
		[Authorize]
		public IHttpResponse All()
		{		
			var games = this.Db.Games.Select(g => new GameListModel()
			{
				Id = g.Id,
				Title = g.Title,
				Price = g.Price,
				Size = g.Size,
			}).ToList();
			var myGames = new GameListViewModel()
			{
				Games = games,
			};
			return this.View(myGames);
		}
		[Authorize]
		public IHttpResponse Edit(int id)
		{
			var game = this.gameService.GetGameById(id);
			if (game == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchIdMessage);
			}
			var model = game.To<GameViewModel>();
			model.ReleaseDate.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture);
			return this.View(model);
		}
		[Authorize]
		[HttpPost("/Games/Edit")]
		public IHttpResponse DoEdit(GameViewModel model)
		{
			var game = this.gameService.GetGameById(model.Id);
			if (game == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchIdMessage);
			}
			this.gameService.EditGame(model);
			return this.RedirectToHome();
		}
		public IHttpResponse Details(int id)
		{
			var game = this.gameService.GetGameById(id);
			if (game == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchIdMessage);
			}
			var model = game.To<GameViewModel>();
			model.ReleaseDate.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture);
			return this.View(model);
		}
		[Authorize]
		public IHttpResponse Delete(int id)
		{
			var game = this.gameService.GetGameById(id);
			if (game == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchIdMessage);
			}
			var model = game.To<GameViewModel>();
			model.ReleaseDate.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture);
			return this.View(model);
		}

		[HttpPost("/Games/Delete")]
		[Authorize]
		public IHttpResponse DoDelete(int id)
		{
			var game = this.gameService.GetGameById(id);
			if (game == null)
			{
				return this.BadRequestErrorWithView(Constants.NoSuchIdMessage);
			}
			this.gameService.DeleteGame(game);
			return this.RedirectToHome();
		}
		private string ValidateGame(GameViewModel model)
		{
			if (!Validator.HasFirstLetterUppercase(model.Title)||!Validator.HasLengthBetween(model.Title,Constants.MinimumGameTitleLength,Constants.MaximumGameTitleLength))
			{
				return Constants.InvalidGameTitleMessage;
			}
			if (!Validator.IsPositive(model.Price))
			{
				return Constants.InvalidPriceMessage;
			}
			if (!Validator.IsPositive(model.Size))
			{
				return Constants.InvalidSizeMessage;
			}

			if (!Validator.HasLengthBetween(model.Trailer,Constants.TrailerLength,Constants.TrailerLength))
			{
				return Constants.InvalidGameTrailerLengthMessage;
			}

			if (!Validator.StartsWithFromList(model.Thumbnail, Constants.ThumbnailPermittedPrefixes))
			{
				return Constants.InvalidThumbnailMessage;
			}

			if (!Validator.IsLongerOrEqualThen(model.Description.Length, Constants.MinimumDescriptionLength))
			{
				return Constants.InvalidGameDescriptionLengthMessage;
			}
			return "";

		}
	}
}