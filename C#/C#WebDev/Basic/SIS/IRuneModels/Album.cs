namespace IRuneModels
{
	using System.Collections.Generic;

	public class Album:BaseModel<string>
	{
		public string Name { get; set; }

		public string Cover { get; set; }
		public decimal Price { get; set; }
		public ICollection<TrackAlbum> Tracks { get; set; }
	}
}
