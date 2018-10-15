namespace IRuneWebApp.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using IRuneData;
	using IRuneModels;
	using Microsoft.EntityFrameworkCore;

	public class AlbumService:IAlbumService
	{
		private readonly IRuneDbContext db;

		public AlbumService()
		{
			this.db = new IRuneDbContext();
		}
		public IEnumerable<Album> GetAllAlbums()
		{
			var albums = this.db.Albums.Include(x => x.Tracks).ToArray();
			return albums;
		}

		public Album CreateAlbum(string name, string cover)
		{
			var album = new Album()
			{
				Name = name,
				Cover = cover,
			};
			this.db.Albums.Add(album);
			this.db.SaveChanges();
			return album;
		}

		public Album GetAlbum(string id)
		{
			var album = this.db.Albums.Include(x=>x.Tracks).ThenInclude(x=>x.Track).FirstOrDefault(x => x.Id==id);
			return album;
		}
	}
}
