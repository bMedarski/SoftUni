namespace StartUp.Server.Routing
{
	using Common;
	using Contracts;
	using Handlers.Contracts;
	using System.Collections.Generic;

	public class RoutingContext : IRoutingContext
    {

	    public RoutingContext(IRequestHandler requestHandler, IEnumerable<string> parameters)
	    {
			Validator.ThrowIfNull(requestHandler,nameof(requestHandler));
		    Validator.ThrowIfNull(parameters, nameof(parameters));

			this.RequestHandler = requestHandler;
		    this.Parameters = parameters;
	    }

	    public IEnumerable<string> Parameters { get; private set; }

	    public IRequestHandler RequestHandler { get; private set; }
    }
}
