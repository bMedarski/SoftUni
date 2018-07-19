using System;
using System.Collections.Generic;
using System.Linq;
using StartUp.Server.Enums;
using StartUp.Server.Handlers.Contracts;
using StartUp.Server.Routing.Contracts;

namespace StartUp.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
	    private readonly IDictionary<HttpRequestMethod, IDictionary<string, IRequestHandler>> routes;

	    public AppRouteConfig()
	    {
		    this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRequestHandler>>();

		    var availableMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();


			foreach (var requestMethod in availableMethods)
		    {
				this.routes[requestMethod] = new Dictionary<string, IRequestHandler>();
		    }
	    }

	    public IDictionary<HttpRequestMethod, IDictionary<string, IRequestHandler>> Routes => this.routes;

	    public void AddRoute(string route, IRequestHandler httpHandler)
	    {
		    if (httpHandler.GetType().ToString().ToLower().Contains("get"))
		    {
			    this.routes[HttpRequestMethod.Get].Add(route, httpHandler);
		    }
		    else if (httpHandler.GetType().ToString().ToLower().Contains("post"))
		    {
			    this.routes[HttpRequestMethod.Post].Add(route, httpHandler);
			}
		    else
		    {
			    throw new InvalidOperationException("Invalid handler");
		    }
		}
    }
}
