using StartUp.Application;

namespace StartUp
{
	using Server;
	using Server.Contracts;
	using Server.Routing;
	using Server.Routing.Contracts;

	class Launcher : IRunnable
	{
		private WebServer webServer;

		static void Main()
		{
			new Launcher().Run();
		}

		public void Run()
		{
			var mainApplication = new MainApplication();
			IAppRouteConfig routeConfig = new AppRouteConfig();
			mainApplication.Start(routeConfig);
			this.webServer = new WebServer(8230, routeConfig);
			this.webServer.Run();
		}
	}
}
