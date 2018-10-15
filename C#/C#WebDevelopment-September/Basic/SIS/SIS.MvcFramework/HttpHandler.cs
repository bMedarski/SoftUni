namespace SIS.MvcFramework
{
	using HTTP.Enums;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;
	using Routers;
	using WebServer.Api;
	using WebServer.Results;
	using WebServer.Routing.Contracts;

	public class HttpHandler : IHttpHandler
	{
		private readonly IServerRoutingTable serverRoutingTable;
		private readonly ResourceHandler resourceHandler;

		public HttpHandler(IServerRoutingTable serverRoutingTable)
		{
			this.serverRoutingTable = serverRoutingTable;
			this.resourceHandler = new ResourceHandler();
		}


		public IHttpResponse Handle(IHttpRequest request)
		{
			if (this.resourceHandler.ReturnIfResource(request.Path))
			{
				return this.resourceHandler.HandleResourceRequest(request);
			}
			if (!this.serverRoutingTable.ContainsMethod(request.RequestMethod) ||
			    !this.serverRoutingTable.ContainsPath(request.RequestMethod,request.Path))
			{
				var status = HttpResponseStatusCode.NotFound;
				return new TextResult($"{(int)status} {status} - Requested path not found", status);
			}

			return this.serverRoutingTable.GetFunction(request.RequestMethod,request.Path).Invoke(request);
		}
	}
}
