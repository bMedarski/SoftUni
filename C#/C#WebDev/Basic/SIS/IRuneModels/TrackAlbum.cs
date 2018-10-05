namespace IRuneModels
{
	public class TrackAlbum :BaseModel<int>
	{
		public string TrackId { get; set; }
		public Track Track { get; set; }

		public string AlbumId { get; set; }
		public Album Album { get; set; }
	}
}
