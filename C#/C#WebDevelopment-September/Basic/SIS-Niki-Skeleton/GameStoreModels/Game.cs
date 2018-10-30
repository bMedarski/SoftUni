namespace GameStoreModels
{
	using System;
	using System.Collections.Generic;

	public class Game
	{
		public Game()
		{
			this.Carts = new HashSet<CartsGames>();
			this.Users = new HashSet<UsersGames>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Trailer { get; set; }
		public string Thumbnail { get; set; }
		public decimal Price { get; set; }
		public decimal Size { get; set; }
		public string Description { get; set; }
		public DateTime ReleaseDate { get; set; }
		public virtual ICollection<UsersGames> Users { get; set; }
		public virtual ICollection<CartsGames> Carts { get; set; }
	}
}
