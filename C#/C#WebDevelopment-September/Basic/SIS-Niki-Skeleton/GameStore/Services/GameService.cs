namespace GameStore.Services
{
	using System.Linq;
	using GameSoreDataNew;
	using GameSoreModelsNew;
	using Microsoft.EntityFrameworkCore;
	using SIS.MvcFramework;
	using ViewModels;

	public class GameService
	{
		private readonly GSdb Db;

		public GameService()
		{
			this.Db = new GSdb();
		}

		public Game GetGameById(int id)
		{
			return this.Db.Games.Include(g=>g.Users).Include(g=>g.Carts).ThenInclude(gc=>gc.Game).Where(g=>g.Id==id).FirstOrDefault();	
		}

		public Game AddGame(GameViewModel gameModel)
		{
			Game game = gameModel.To<Game>();
			this.Db.Games.Add(game);
			this.Db.SaveChanges();
			return game;
		}

		public Game EditGame(GameViewModel gameModel)
		{
			Game game = this.GetGameById(gameModel.Id);
			game.Title = gameModel.Title;
			game.Description = gameModel.Description;
			game.Price = gameModel.Price;
			game.Size = gameModel.Size;
			game.Thumbnail = gameModel.Thumbnail;
			game.ReleaseDate = gameModel.ReleaseDate;
			game.Trailer = gameModel.Trailer;
			this.Db.SaveChanges();
			return game;
		}
		public void DeleteGame(Game game)
		{
			this.Db.Games.Remove(game);
			this.Db.SaveChanges();
		}
	}
}
