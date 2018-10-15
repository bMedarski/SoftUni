namespace IRuneWebApp
{
	using Controllers;
	using SIS.HTTP.Enums;
	using SIS.MvcFramework;
	using SIS.WebServer;
	using SIS.WebServer.Results;
	using SIS.WebServer.Routing;
	using SIS.WebServer.Routing.Contracts;

	public class Launcher
	{
		static void Main()
		{
			IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
			GetRoutes(serverRoutingTable);
			var handler = new HttpHandler(serverRoutingTable);
			Server server = new Server(8000, handler);
			server.Run();
		}

		private static void GetRoutes(IServerRoutingTable serverRoutingTable)
		{
			serverRoutingTable.Add(HttpRequestMethod.Get,"/",request => new HomeController().Index(request));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Home/Index",request => new RedirectResult("/"));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Home/SignIn",request => new HomeController().SignIndex(request));

			serverRoutingTable.Add(HttpRequestMethod.Get,"/Users/Register",request => new UsersController().Register(request));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Users/Login",request => new UsersController().Login(request));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Users/Logout",request => new UsersController().Logout(request));
			serverRoutingTable.Add(HttpRequestMethod.Post,"/Users/Register",request => new UsersController().Register(request));
			serverRoutingTable.Add(HttpRequestMethod.Post,"/Users/Login",request => new UsersController().Login(request));

			serverRoutingTable.Add(HttpRequestMethod.Get,"/Albums/All",request => new AlbumsController().All(request));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Albums/Create",request => new AlbumsController().Create(request));
			serverRoutingTable.Add(HttpRequestMethod.Post,"/Albums/Create",request => new AlbumsController().Create(request));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Albums/Details",request => new AlbumsController().Details(request));

			serverRoutingTable.Add(HttpRequestMethod.Get,"/Tracks/Create",request => new TracksController().Create(request));
			serverRoutingTable.Add(HttpRequestMethod.Post,"/Tracks/Create",request => new TracksController().Create(request));
			serverRoutingTable.Add(HttpRequestMethod.Get,"/Tracks/Details",request => new TracksController().Details(request));
		}
	}
}
