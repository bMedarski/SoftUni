namespace IRuneWebApp
{
	using Controllers;
	using SIS.HTTP.Enums;
	using SIS.WebServer;
	using SIS.Webserver.Results;
	using SIS.Webserver.Routing;
	using SIS.Webserver.Routing.Contracts;

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
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/Home/Index",request => new RedirectResult("/"));
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/Users/Register",request => new UsersController().Register(request));
			serverRoutingTable.AddRoute(HttpRequestMethod.Get,"/Users/Login",request => new UsersController().Login(request));
		}
	}
}
