namespace SIS.Demo
{
	using HTTP.Enums;
	using Webserver;
	using Webserver.Routing;
	using WebServer;

	public class Launcher
    {
        static void Main()
        {
            
			ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
			serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();
			Server server = new Server(8000,serverRoutingTable);
			server.Run();
        }
    }
}
