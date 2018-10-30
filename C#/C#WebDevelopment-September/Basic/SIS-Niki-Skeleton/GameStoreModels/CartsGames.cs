﻿namespace GameStoreModels
{
	public class CartsGames
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public virtual Cart Cart { get; set; }
		public int GameId { get; set; }
		public virtual Game Game { get; set; }
	}
}
