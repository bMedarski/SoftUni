namespace IRuneWebApp.Controllers
{
	using System.Globalization;
	using System.Linq;
	using Extensions;
	using Models;
	using Services.Contracts;
	using SIS.MvcFramework.ActionResults.Contracts;
	using SIS.MvcFramework.Attributes.Method;
	using SIS.MvcFramework.Controllers;

	public class TracksController : Controller
	{
		private readonly ITracksService tracksService;

		public TracksController(ITracksService tracksService)
		{
			this.tracksService = tracksService;
		}

		[HttpGet]
		public IActionResult Create(string id)
		{
			this.ViewModel["SignIn"] = "";
			this.ViewModel["SignOff"] = "hidden";
			this.ViewModel["AlbumId"] = id;
			return this.View();
		}

		[HttpPost]
		public IActionResult Create(TrackViewModel model)
		{
			var trackName = model.Name;
			var trackLink = model.Link;
			var albumId = model.Id;
			var price = decimal.Parse(model.Price.ToString(CultureInfo.InvariantCulture));
			this.tracksService.Create(trackName, trackLink, price, albumId);

			return this.RedirectToAction($"/Albums/Details?id={albumId}");
		}
		public IActionResult Details(string id)
		{
			var trackId = id;
			var track = this.tracksService.GetTrack(trackId);
			this.ViewModel["Name"] = track.Name;
			this.ViewModel["Price"] = track.Price.ToString(CultureInfo.InvariantCulture);
			this.ViewModel["Link"] = track.Link.Decode();
			this.ViewModel["AlbumId"] = track.Albums.Where(t => t.TrackId == trackId).FirstOrDefault().AlbumId;
			this.ViewModel["SignIn"] = "";
			this.ViewModel["SignOff"] = "hidden";
			return this.View();
		}
	}
}
