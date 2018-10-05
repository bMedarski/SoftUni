namespace IRuneWebApp
{
	using Controllers;
	using SIS.HTTP.Enums;
	using SIS.Webserver.Routing;
	using SIS.Webserver.Routing.Contracts;
	using SIS.WebServer;

	public class Launcher
	{
		static void Main()
		{
			ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
			GetRoutes(serverRoutingTable);
			Server server = new Server(8000, serverRoutingTable);
			server.Run();
		}

		private static void GetRoutes(IServerRoutingTable serverRoutingTable)
		{
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/",request => new HomeController().Index(request));
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/Home/Index",request => new HomeController().Index(request));
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/Users/Register",request => new HomeController().Index(request));
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/Users/Login",request => new HomeController().Index(request));
		}
	}
}
