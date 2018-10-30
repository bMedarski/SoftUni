namespace GameStore.Controllers
{
	using System.Linq;
	using Microsoft.EntityFrameworkCore;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels;

	public class HomeController:BaseController
	{
		public IHttpResponse Index()
		{
			var games = this.Db.Games.Select(g => new GameViewModel()
			{
				Description = g.Description.Substring(0, 300),
				Id = g.Id,
				Title = g.Title,
				Price = g.Price,
				Size = g.Size,
				Thumbnail = g.Thumbnail,
				Trailer = g.Trailer,
				ReleaseDate = g.ReleaseDate

			}).ToList();
			var myGames = new HomeViewModel
			{
				Games = games,
			};
			return this.View(myGames);
		}
		[HttpPost]
		public IHttpResponse Index(string filter)
		{
			var games = new HomeViewModel();
			if (filter == "All")
			{
				var allGames = this.Db.Games.Include(u => u.Users).Select(g => g.To<GameViewModel>());
				games.Games = allGames.ToList();
			}
			else
			{
				var userId = this.Db.Users.Where(u => u.Email == this.User.Username).Select(u => u.Id).FirstOrDefault();
				//games = this.Db.Users.Where(g => g.Email == this.User.Username).Include(u=>u.Games).ThenInclude(q=>q.Game).Select(g =>
				//{
				//	g.Games.Select(us => new GameViewModel()
				//	{
				//		Title = us.Game.Title,
				//		Description = us.Game.Description,
				//	}).ToList();
				//}).ToList();


				var userGames = this.Db.Games
					.Include(e => e.Users)
					.ThenInclude(e => e.User)
					.ToList();
				var allGames = this.Db.Games.Include(u => u.Users).Select(g => g.To<GameViewModel>());
				games.Games = allGames.ToList();
			}
			
			return this.View(games);
		}
	}
}
