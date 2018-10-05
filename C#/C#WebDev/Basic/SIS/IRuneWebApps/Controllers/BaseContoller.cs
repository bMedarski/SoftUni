namespace IRuneWebApp.Controllers
{
	using System;
	using System.Runtime.CompilerServices;
	using SIS.HTTP.Enums;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public abstract class BaseContoller
	{
		private const string RootDirectoryRelativePath = "../../../";
		private const string ViewFolderName = "Views";
		private const string DirectoryDelimeter = "/";
		private const string ControllerDefaultName = "Controller";
		private const string HtmlSuffix = ".html";

		protected IHttpResponse View([CallerMemberName] string viewName="")
		{

			var filePah = this.GetFilePath(viewName);

			return new HtmlResult(filePah,HttpResponseStatusCode.Ok);
		}

		private string GetFilePath(string viewName)
		{
			var controllerName = this.GetCurrentControllerName();
			return $"{RootDirectoryRelativePath}{ViewFolderName}{DirectoryDelimeter}{controllerName}{DirectoryDelimeter}{viewName}{HtmlSuffix}";
		}

		private string GetCurrentControllerName()
		{
			return this.GetType().Name.Replace(ControllerDefaultName, string.Empty);
		}
	}
}
