namespace IRuneWebApp.Controllers
{
	using System.Globalization;
	using System.Linq;
	using Extensions;
	using Services;
	using Services.Contracts;
	using SIS.HTTP.Enums;
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;
	using SIS.WebServer.Results;

	public class TracksController:BaseController
	{
		private const string TitleCreateTrack = "Create Track";
		private const string TitleDetailTrack = "Track Details";

		private readonly ITracksService tracksService;
		public TracksController()
		{
			this.tracksService= new TracksService();
		}
		public IHttpResponse Create(IHttpRequest request)
		{
			this.viewBag["Title"] = TitleCreateTrack;
			this.viewBag["SignIn"] = "";
			this.viewBag["SignOff"] = "hidden";
			if (request.RequestMethod==HttpRequestMethod.Get)
			{
				if(!this.userService.IsAuthenticated(request))
				{
					return new RedirectResult("/");
				}
				this.viewBag["AlbumId"] = request.QueryData["id"].ToString();
				return this.View();
			}
			else
			{
				var trackName = request.FormData["name"].ToString().Decode();
				var trackLink = request.FormData["link"].ToString().Decode();
				var albumId = request.FormData["id"].ToString().Decode();
				var price = decimal.Parse(request.FormData["price"].ToString().Decode(), CultureInfo.InvariantCulture);
				this.tracksService.Create(trackName, trackLink, price, albumId);

				return new RedirectResult($"/Albums/Details?id={albumId}");
			}

		}
		public IHttpResponse Details(IHttpRequest request)
		{
			if(!this.userService.IsAuthenticated(request))
			{
				return new RedirectResult("/");
			}
			this.viewBag["Title"] = TitleDetailTrack;
			var trackId = request.QueryData["id"].ToString();
			var track = this.tracksService.GetTrack(trackId);
			this.viewBag["Name"] = track.Name;
			this.viewBag["Price"] = track.Price.ToString(CultureInfo.InvariantCulture);
			this.viewBag["Link"] = track.Link.Decode();
			this.viewBag["AlbumId"] = track.Albums.Where(t => t.TrackId == trackId).FirstOrDefault().AlbumId;
			this.viewBag["SignIn"] = "";
			this.viewBag["SignOff"] = "hidden";
			return this.View();
		}
	}
}
