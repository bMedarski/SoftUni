namespace SIS.MvcFramework.Routers
{
	using System.Linq;
	using HTTP.Common;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;
	using Webserver.Api;
	using WebServer.Api;

	public class HttpRouteHandlingContext:IHttpHandlingContext
	{
		public HttpRouteHandlingContext(
			IHttpHandler controllerHandler,
			IHttpHandler resourceHandler)
		{
			this.ControllerHandler = controllerHandler;
			this.ResourceHandler = resourceHandler;
		}

		protected IHttpHandler ControllerHandler { get; }

		protected IHttpHandler ResourceHandler { get; }

		public IHttpResponse Handle(IHttpRequest request)
		{
			if (this.ReturnIfResource(request.Path))
			{
				return this.ResourceHandler.Handle(request);
			}

			return this.ControllerHandler.Handle(request);
		}
		public bool ReturnIfResource(string path)
		{
			if (GlobalConstants.PermittedResourceExtensions.Contains(this.GetResourceExtension(path)))
			{
				return true;
			}
			return false;
		}
		private string GetResourceExtension(string path)
		{
			return path.Split(".").Last();
		}
	}
}
