using System;
using SoftUni.WebServer.Mvc;
using SoftUni.WebServer.Mvc.Routers;
using SoftUni.WebServer.Server;

namespace CHUSHKA.App
{
    public class Launcher
    {
		public static void Main()
		{
			var server = new WebServer(4444, new ControllerRouter(), new ResourceRouter());

			MvcEngine.Run(server);
		}
	}
}
