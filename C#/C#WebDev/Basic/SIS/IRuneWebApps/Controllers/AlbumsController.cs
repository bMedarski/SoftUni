namespace IRuneWebApp.Controllers
{
	using System.Linq;
	using System.Text;
	using Extensions;
	using Services;
	using Services.Contracts;
	using SIS.HTTP.Enums;
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public class AlbumsController : BaseContoller
	{
		private const decimal MultiplyCoeficientForAlbumPrice = 0.87m;
		private const string NoAlbumsMessage = "There are currently no albums.";
		private const string TitleForAllAlbums = "All Albums";
		private const string TitleForCreateAlbum = "Create Album";
		private const string TitleForAlbumDetails = "Album Details";

		private readonly IAlbumService albumService;
		public AlbumsController()
		{
			this.albumService = new AlbumService();
		}
		public IHttpResponse All(IHttpRequest request)
		{
			this.viewBag["Title"] = TitleForAllAlbums;
			var albums = this.albumService.GetAllAlbums();
			if (!albums.Any())
			{
				this.viewBag["AlbumList"] = NoAlbumsMessage;
			}
			else
			{
				var sb = new StringBuilder();
				foreach (var album in albums)
				{
					sb.AppendLine($"<p><a href=/Albums/Details?id={album.Id}>{album.Name}</a></p>");
				}

				sb.AppendLine("<hr/>");
				this.viewBag["AlbumList"] = sb.ToString();
				this.viewBag["AlbumList"] = sb.ToString();
			}
			return this.View();
		}
		public IHttpResponse Create(IHttpRequest request)
		{
			this.viewBag["Title"] = TitleForCreateAlbum;
			if (request.RequestMethod == HttpRequestMethod.Get)
			{
				return this.View();
			}
			else
			{
				var albumName = request.FormData["name"].ToString().Decode();
				var albumCover = request.FormData["cover"].ToString().Decode();
				this.albumService.CreateAlbum(albumName, albumCover);
				return new RedirectResult("/Albums/All");
			}
		}

		public IHttpResponse Details(IHttpRequest request)
		{
			var albumId = request.QueryData["id"].ToString();
			var album = this.albumService.GetAlbum(albumId);

			if (album == null)
			{
				this.viewBag["Error"] = "No such album";
				return this.View(BadRequestViewName,"Common");
			}
			var price = album.Price * MultiplyCoeficientForAlbumPrice;
			var tracks = album.Tracks.ToArray();
			var tracksText = new StringBuilder();
			tracksText.AppendLine("<ul>");
			for (int i = 0; i < tracks.Length; i++)
			{
				tracksText.AppendLine($"<li>{i+1}.<a href=/Tracks/Details?id={tracks[i].TrackId}>{tracks[i].Track.Name}</a></li>");
			}
			tracksText.AppendLine("</ul>");
			this.viewBag["AlbumId"] = albumId;
			this.viewBag["Title"] = TitleForAlbumDetails;
			this.viewBag["Cover"] = album.Cover;
			this.viewBag["Name"] = album.Name;
			this.viewBag["Tracks"] = tracksText.ToString();
			if (price == null)
			{
				price = 0;
			}
			this.viewBag["Price"] = ((double)(price)).ToString("F2");
			return this.View();
		}
	}
}
