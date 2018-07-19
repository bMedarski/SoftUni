namespace StartUp.Server.Handlers
{
	using Contracts;
	using HTTP.Contracts;
	using HTTP.Response;
	using Routing.Contracts;
	using System.Text.RegularExpressions;

	public class HttpHandler: IRequestHandler
    {
	    private readonly IServerRouteConfig serverRouteConfig;

	    public HttpHandler(IServerRouteConfig serverRouteConfig)
	    {
		    this.serverRouteConfig = serverRouteConfig;
	    }

	    public IHttpResponse Handle(IHttpContext context)
	    {
		    var requestMethod = context.Request.RequestMethod;
		    var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];
		    var registeredPath = context.Request.Path;

			foreach (var registeredRoute in registeredRoutes)
		    {
			    string pattern = registeredRoute.Key;

				var regex = new Regex(pattern);
			    var match = regex.Match(registeredPath);

			    if (!match.Success)
			    {
				    continue;
			    }

			    var parameters = registeredRoute.Value.Parameters;

				foreach (var parameter in parameters)
			    {
				    context.Request.AddUrlParameter(parameter,match.Groups[parameter].Value);
			    }

			    return registeredRoute.Value.RequestHandler.Handle(context);
		    }
			return new NotFoundResponse();
	    }
    }
}
