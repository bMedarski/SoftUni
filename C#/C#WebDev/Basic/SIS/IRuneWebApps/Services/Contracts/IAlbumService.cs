namespace IRuneWebApp.Services.Contracts
{
	using System.Collections.Generic;
	using IRuneModels;

	public interface IAlbumService
	{
		IEnumerable<Album> GetAllAlbums();
		Album CreateAlbum(string name, string cover);
		Album GetAlbum(string id);
	}
}
