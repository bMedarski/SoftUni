namespace MishMashWebApp.Services
{
	using MIshMashData;

	public class ChannelsService
	{
		private MishMashDbContext Db { get; set; }

		public ChannelsService(MishMashDbContext db)
		{
			this.Db = db;
		}


	}
}
