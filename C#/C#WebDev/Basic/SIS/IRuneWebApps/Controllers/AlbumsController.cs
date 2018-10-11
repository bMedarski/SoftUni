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

	public class AlbumsController : BaseController
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
			if(!this.userService.IsAuthenticated(request))
			{
				return new RedirectResult("/");
			}
			this.viewBag["Title"] = TitleForAllAlbums;
			this.viewBag["SignIn"] = "";
			this.viewBag["SignOff"] = "hidden";
			var albums = this.albumService.GetAllAlbums();
			if (!albums.Any())
			{
				this.viewBag["AlbumList"] = NoAlbumsMessage;
			}
			else
			{
				var sb = new StringBuilder();
				sb.AppendLine("<Section class='album-list'>");
				foreach (var album in albums)
				{
					sb.AppendLine($"<div><a href=/Albums/Details?id={album.Id}><strong>{album.Name}</strong></a></div>");
				}
				sb.AppendLine("</Section>");
				this.viewBag["AlbumList"] = sb.ToString();
				this.viewBag["AlbumList"] = sb.ToString();
			}
			return this.View();
		}
		public IHttpResponse Create(IHttpRequest request)
		{
			this.viewBag["Title"] = TitleForCreateAlbum;
			this.viewBag["SignIn"] = "";
			this.viewBag["SignOff"] = "hidden";
			if (request.RequestMethod == HttpRequestMethod.Get)
			{
				if(!this.userService.IsAuthenticated(request))
				{
					return new RedirectResult("/");
				}
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
			if(!this.userService.IsAuthenticated(request))
			{
				return new RedirectResult("/");
			}
			var albumId = request.QueryData["id"].ToString();
			var album = this.albumService.GetAlbum(albumId);

			if (album == null)
			{
				this.viewBag["Error"] = "No such album";
				return this.View(BadRequestViewName,"Common");
			}
			var price = album.Price * MultiplyCoeficientForAlbumPrice;
			var tracks = album.Tracks.ToArray();
			if (tracks.Any())
			{
				var tracksText = new StringBuilder();
				tracksText.AppendLine("<ul>");
				for (int i = 0; i < tracks.Length; i++)
				{
					tracksText.AppendLine($"<li>{i+1}.<a href=/Tracks/Details?id={tracks[i].TrackId}>{tracks[i].Track.Name}</a></li>");
				}
				tracksText.AppendLine("</ul>");
				this.viewBag["Tracks"] = tracksText.ToString();
			}
			else
			{
				this.viewBag["Tracks"] = "<p><strong>No Tracks yet.</strong></p>";
			}

			this.viewBag["AlbumId"] = albumId;
			this.viewBag["Title"] = TitleForAlbumDetails;
			this.viewBag["Cover"] = album.Cover;
			this.viewBag["Name"] = album.Name;

			this.viewBag["SignIn"] = "";
			this.viewBag["SignOff"] = "hidden";
			if (price == null)
			{
				price = 0;
			}
			this.viewBag["Price"] = ((double)(price)).ToString("F2");
			return this.View();
		}
	}
}
