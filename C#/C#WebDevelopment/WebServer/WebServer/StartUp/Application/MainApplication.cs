namespace StartUp.Application
{
	using Contracts;
	using Controllers;
	using Server.Handlers;
	using Server.Routing.Contracts;

	public class MainApplication: IApplication
	{
		public void Start(IAppRouteConfig routeConfig)
		{
			routeConfig.AddRoute("/",new GetHandler(request => new HomeController().Index()));

			routeConfig.AddRoute("/register",new GetHandler(request => new UserController().RegisterGet()));

			routeConfig.AddRoute("/register", new PostHandler(request => new UserController().RegisterPost(request.FormData["name"])));

			routeConfig.AddRoute("/user/{(?<name>[a-z]+)}", new GetHandler(request => new UserController().Details(request.UrlParameters["name"])));
		}
    }
}
