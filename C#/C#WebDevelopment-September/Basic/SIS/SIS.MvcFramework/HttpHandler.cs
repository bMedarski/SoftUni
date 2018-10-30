namespace SIS.MvcFramework
{
	using System;
	using HTTP.Enums;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;
	using Routers;
	using WebServer.Api;

	public class HttpHandler : IHttpHandler
	{
		private readonly ResourceHandler resourceHandler;
		private readonly ControllerRouter controllerRouter;

		public HttpHandler(ResourceHandler resourceHandler, ControllerRouter controllerRouter)
		{
			this.resourceHandler = resourceHandler;
			this.controllerRouter = controllerRouter;
		}


		public IHttpResponse Handle(IHttpRequest request)
		{

			Console.WriteLine();
			if (this.resourceHandler.ReturnIfResource(request.Path))
			{
				return this.resourceHandler.Handle(request);
			}
			return this.controllerRouter.Handle(request);
		}
	}
}
