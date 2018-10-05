namespace IRuneWebApps
{
	using Controllers;
	using SIS.HTTP.Enums;
	using SIS.Webserver.Routing;
	using SIS.WebServer;

	class Launcher
	{
		static void Main()
		{
			ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
			serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);
			Server server = new Server(8000,serverRoutingTable);
			server.Run();
		}
	}
}
