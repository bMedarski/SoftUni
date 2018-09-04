using MyCoolWebServer.GameStoreApplication.Cotrollers;
using MyCoolWebServer.Server.Routing.Contracts;

namespace MyCoolWebServer.GameStoreApplication
{
	public class GameStoreApp
	{
		public void InitializeDatabase()
		{
			//using (var db = new ByTheCakeDbContext())
			{
			//	db.Database.Migrate();
			}
		}

		public void Configure(IAppRouteConfig appRouteConfig)
		{
			appRouteConfig
				.Get("/", req => new HomeController().Index());

		}
	}
}
