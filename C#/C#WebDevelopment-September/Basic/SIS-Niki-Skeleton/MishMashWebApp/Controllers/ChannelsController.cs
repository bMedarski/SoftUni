namespace MishMashWebApp.Controllers
{
	using MIshMashData;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Channels;

	public class ChannelsController:BaseController
	{
		private ChannelsService ChannelsService { get; set; }

		public ChannelsController(MishMashDbContext db,ChannelsService channelsService)
		:base(db)
		{
			this.ChannelsService = channelsService;
		}

		[Authorize("Admin")]
		public IHttpResponse Create()
		{
			return this.View();
		}

		[Authorize("Admin")]
		[HttpPost]
		public IHttpResponse Create(ChannelCreateViewModel model)
		{

			return this.View();
		}
	}
}
