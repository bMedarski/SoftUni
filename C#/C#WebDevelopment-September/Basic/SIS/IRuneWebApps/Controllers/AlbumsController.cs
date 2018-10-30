namespace IRuneWebApp.Controllers
{
	using System.Linq;
	using System.Text;
	using Models;
	using Services.Contracts;
	using SIS.MvcFramework.ActionResults.Contracts;
	using SIS.MvcFramework.Attributes.Method;
	using SIS.MvcFramework.Controllers;

	public class AlbumsController : Controller
	{
		private const decimal MultiplyCoeficientForAlbumPrice = 0.87m;
		private const string NoAlbumsMessage = "There are currently no albums.";
		private readonly IAlbumService albumService;

		public AlbumsController(IAlbumService albumService)
		{
			this.albumService = albumService;
		}

		[HttpGet]
		public IActionResult All()
		{
			if (this.Identity() != null)
			{
				this.ViewModel["SignIn"] = "";
				this.ViewModel["SignOff"] = "hidden";
				var albums = this.albumService.GetAllAlbums();
				if (!albums.Any())
				{
					this.ViewModel["AlbumList"] = NoAlbumsMessage;
				}
				else
				{
					var sb = new StringBuilder();
					sb.AppendLine("<Section class='album-list'>");
					foreach (var album in albums)
					{
						sb.AppendLine(
							$"<div><a href=/Albums/Details?id={album.Id}><strong>{album.Name}</strong></a></div>");
					}

					sb.AppendLine("</Section>");
					this.ViewModel["AlbumList"] = sb.ToString();
					this.ViewModel["AlbumList"] = sb.ToString();
				}
				return this.View();
			}
			return this.RedirectToAction("/Users/Login");
		}

		[HttpGet]
		public IActionResult Create()
		{
			if (this.Identity() != null)
			{
				this.ViewModel["SignIn"] = "";
				this.ViewModel["SignOff"] = "hidden";
				return this.View();
			}
			return this.RedirectToAction("/Users/Login");
		}
		[HttpPost]
		public IActionResult Create(AlbumViewModel model)
		{
			if (this.Identity() != null)
			{
				if (!this.ModelState.IsValid.HasValue || !this.ModelState.IsValid.Value)
				{
					this.ViewModel.Data["error"] = "Wrong album data";
					return this.RedirectToAction("/Users/Login");
				}
				var albumName = model.Name;
				var albumCover = model.Cover;
				this.albumService.CreateAlbum(albumName, albumCover);
				return this.RedirectToAction("/Albums/All");
			}
			return this.RedirectToAction("/Users/Login");
		}

		[HttpGet]
		public IActionResult Details(string id)
		{
			if (this.Identity() != null)
			{
				var albumId = this.Request.QueryData["id"].ToString();
				var album = this.albumService.GetAlbum(albumId);

				if (album == null)
				{
					this.ViewModel["error"] = "No such album";
					return this.RedirectToAction("/Albums/All");
				}
				var price = album.Price * MultiplyCoeficientForAlbumPrice;
				var tracks = album.Tracks.ToArray();
				if (tracks.Any())
				{
					var tracksText = new StringBuilder();
					tracksText.AppendLine("<ul>");
					for (int i = 0; i < tracks.Length; i++)
					{
						tracksText.AppendLine($"<li>{i + 1}.<a href=/Tracks/Details?id={tracks[i].TrackId}>{tracks[i].Track.Name}</a></li>");
					}
					tracksText.AppendLine("</ul>");
					this.ViewModel["Tracks"] = tracksText.ToString();
				}
				else
				{
					this.ViewModel["Tracks"] = "<p><strong>No Tracks yet.</strong></p>";
				}

				this.ViewModel["AlbumId"] = albumId;
				this.ViewModel["Cover"] = album.Cover;
				this.ViewModel["Name"] = album.Name;

				this.ViewModel["SignIn"] = "";
				this.ViewModel["SignOff"] = "hidden";
				if (price == null)
				{
					price = 0;
				}
				this.ViewModel["Price"] = ((double)(price)).ToString("F2");
				return this.View();
			}
			return this.RedirectToAction("/Users/Login");
		}
	}
}
