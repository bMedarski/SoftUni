namespace IRuneWebApp.Services
{
	using System.Linq;
	using Contracts;
	using IRuneData;
	using IRuneModels;
	using Microsoft.EntityFrameworkCore;

	public class TracksService:ITracksService
	{
		private readonly IRuneDbContext db;

		public TracksService()
		{
			this.db = new IRuneDbContext();
		}

		public Track Create(string name, string link, decimal price, string albumId)
		{
			var track = new Track()
			{
				Name = name,
				Link = link,
				Price = price
			};
			this.db.Tracks.Add(track);
			var album = this.db.Albums.Where(a => a.Id == albumId).FirstOrDefault();

			var albumTrack = new TrackAlbum()
			{
				Album = album,
				AlbumId = albumId,
				Track = track,
				TrackId = track.Id
			};
			this.db.TrackAlbums.Add(albumTrack);

			this.db.SaveChanges();
			return track;
		}

		public Track GetTrack(string id)
		{
			var track = this.db.Tracks.Include(t=>t.Albums).Where(t => t.Id == id).FirstOrDefault();
			return track;
		}
	}
}
