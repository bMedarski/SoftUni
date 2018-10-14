namespace SIS.MvcFramework.Routers
{
	using System.IO;
	using System.Linq;
	using HTTP.Common;
	using HTTP.Enums;
	using HTTP.Extensions;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;
	using WebServer.Results;

	public class ResourceHandler
	{
		private const string resourceFolder = "../../../Resources/";

		public IHttpResponse HandleResourceRequest(IHttpRequest request)
		{
			var path = request.Path;
			var resourceName =path.Split("/").Last().TrimEndWithText(this.GetResourceExtension(path))+this.GetResourceExtension(path);
			var resource = resourceFolder + this.GetResourceExtension(path) +"/"+ resourceName;
			var content = File.ReadAllBytes(resource);
			return new InlineResourceResult(content, HttpResponseStatusCode.Ok);
		}
		private string GetResourceExtension(string path)
		{
			return path.Split(".").Last();
		}
		public bool ReturnIfResource(string path)
		{
			if (GlobalConstants.PermittedResourceExtensions.Contains(this.GetResourceExtension(path)))
			{
				return true;
			}
			return false;
		}
	}
}
