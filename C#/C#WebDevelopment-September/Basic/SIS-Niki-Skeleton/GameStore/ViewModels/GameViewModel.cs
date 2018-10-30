namespace GameStore.ViewModels
{
	using System;

	public class GameViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Size { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Trailer { get; set; }
		public string Thumbnail { get; set; }
		public int? UserId { get; set; }
	}
}
