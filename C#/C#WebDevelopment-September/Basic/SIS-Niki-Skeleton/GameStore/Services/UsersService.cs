namespace GameStore.Services
{
	using System.Linq;
	using GameSoreDataNew;
	using GameSoreModelsNew;
	using Microsoft.EntityFrameworkCore.Internal;
	using SIS.MvcFramework;
	using SIS.MvcFramework.Services;
	using ViewModels;


	public class UsersService:Controller
	{
		private readonly HashService hashService;
		private readonly GSdb Db;

		public UsersService(HashService hashService)
		{
			this.Db = new GSdb();
			this.hashService = hashService;
		}

		public User CreateUser(RegisterInputViewModel model)
		{
			var hashedPassword = this.hashService.Hash(model.Password);

			var role = Role.User;
			if (!EnumerableExtensions.Any(this.Db.Users))
			{
				role = Role.Administrator;
			}
			var user = new User
			{
				FullName = model.Fullname.Trim(),
				Email = model.Email.Trim(),
				Password = hashedPassword,
				Role = role,
				Cart = new Cart()
			};
			this.Db.Users.Add(user);
			this.Db.SaveChanges();
			return user;
		}

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			var hashedPassword = this.hashService.Hash(password);

			var user = this.Db.Users.Where(u => u.Email == username && u.Password == hashedPassword)
				.FirstOrDefault();
			return user;
		}
		public User GetUserByUsername(string username)
		{
			var user = this.Db.Users.Where(u=>u.Email==username).FirstOrDefault();
			return user;
		}

		public void BuyGame(Game game, User user)
		{
			var cart = user.Cart;
			var cartGames = new CartGame{CartId = cart.Id,GameId = game.Id};
			this.Db.CartGames.Add(cartGames);
			this.Db.SaveChanges();
		}
		public void Order(string username)
		{
			var user = this.GetUserByUsername(username);
			var games = user.Cart.Games;
			foreach (var game in games)
			{
				var userGame = new UserGame();
				userGame.Game = game.Game;
				userGame.User = user;
				this.Db.UserGames.Add(userGame);
				this.Db.SaveChanges();
			}
			user.Cart.Games.Clear();
			this.Db.SaveChanges();
		}
	}
}
