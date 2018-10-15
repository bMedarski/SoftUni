namespace IRuneModels
{
	using System.Collections.Generic;

	public class Track:BaseModel<string>
	{
		public Track()
		{
			this.Albums = new HashSet<TrackAlbum>();
		}
		public string Name { get; set; }
		public string Link { get; set; }
		public decimal Price { get; set; }
		public ICollection<TrackAlbum> Albums { get; set; }

	}
}
