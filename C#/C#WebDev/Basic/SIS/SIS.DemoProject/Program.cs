namespace SIS.DemoProject
{
	using MvcFramework;
	using MvcFramework.Routers;
	using WebServer;

	class Program
	{
		static void Main()
		{
			var server = new Server(8000, new ControllerRouter());

			MvcEngine.Run(server);
		}
	}
}
