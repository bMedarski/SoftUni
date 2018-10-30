namespace GameStore.ViewModels
{
	using System;

	public class DetailViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Trailer { get; set; }
		public decimal Price { get; set; }
		public decimal Size { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}
