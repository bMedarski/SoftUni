namespace GameSoreModelsNew
{
	using System;
	using System.Collections.Generic;

	public class Game
	{
		public Game()
		{
			this.Carts = new List<CartGame>();
			this.Users = new List<UserGame>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Trailer { get; set; }
		public string Thumbnail { get; set; }
		public decimal Price { get; set; }
		public decimal Size { get; set; }
		public string Description { get; set; }
		public DateTime ReleaseDate { get; set; }
		public virtual ICollection<UserGame> Users { get; set; }
		public virtual ICollection<CartGame> Carts { get; set; }
	}
}
