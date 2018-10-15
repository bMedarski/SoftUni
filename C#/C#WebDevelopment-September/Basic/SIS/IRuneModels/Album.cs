namespace IRuneModels
{
	using System.Collections.Generic;
	using System.Linq;

	public class Album:BaseModel<string>
	{
		public Album()
		{
			this.Tracks = new HashSet<TrackAlbum>();
		}
		public string Name { get; set; }
		public string Cover { get; set; }
		public decimal? Price => this.Tracks.Sum(t => t.Track.Price) * 0.87m;
		
		public ICollection<TrackAlbum> Tracks { get; set; }
	}
}
