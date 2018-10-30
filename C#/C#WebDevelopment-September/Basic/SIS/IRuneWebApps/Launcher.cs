namespace IRuneWebApp
{
	using System;
	using System.Collections.Generic;
	using Services;
	using Services.Contracts;
	using SIS.MvcFramework;
	using SIS.MvcFramework.Routers;
	using SIS.MvcFramework.Services;
	using SIS.WebServer;

	public class Launcher
	{
		static void Main()
		{
			var dependencyMap = new Dictionary<Type, Type>();            
			var dependencyContainer = new DependencyContainer(dependencyMap);
			dependencyContainer.RegisterDependency<IHashService, HashService>();
			dependencyContainer.RegisterDependency<IUserService, UserService>();
			dependencyContainer.RegisterDependency<IAlbumService, AlbumService>();
			dependencyContainer.RegisterDependency<ITracksService, TracksService>();

			var handlingContext = new HttpRouteHandlingContext(
				new ControllerRouter(dependencyContainer),
				new ResourceHandler());
			Server server = new Server(80, handlingContext);
			var engine = new MvcEngine();
			engine.Run(server);
		}
	}
}
