namespace IRuneWebApp.Controllers
{
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.CompilerServices;
	using Services;
	using Services.Contracts;
	using SIS.HTTP.Enums;
	using SIS.HTTP.Responses.Contracts;
	using SIS.Webserver.Results;

	public abstract class BaseController
	{
		private const string RootDirectoryRelativePath = "../../../";
		private const string ViewFolderName = "Views";
		private const string DirectoryDelimeter = "/";
		private const string ControllerDefaultName = "Controller";
		private const string HtmlSuffix = ".html";
		private const string FooterPath = "../../../Views/Common/_footer.html";
		private const string NavigationPath = "../../../Views/Common/_navigation.html";
		private const string LayoutPath = "../../../Views/Common/_layout.html";
		private const string ReplacementPreffix = "@Model.";
		private const string ReplacementBodyText = "@RenderBody()";
		protected const string BadRequestViewName = "BadRequestView";
		
		protected readonly IUserService userService;
		protected IDictionary<string, string> viewBag;

		protected BaseController()
		{
			this.userService = new UserService();
			this.viewBag = new Dictionary<string, string>();
		}
		protected IHttpResponse View([CallerMemberName] string viewName="", string controller="")
		{
			var footer = File.ReadAllText(FooterPath);
			var navigation = File.ReadAllText(NavigationPath);

			navigation = this.ReplaceMarkers(navigation);
			this.viewBag["Footer"]=footer;
			this.viewBag["Navigation"]=navigation;

			var allContent = this.GetViewContent(viewName, controller);

			return new HtmlResult(allContent,HttpResponseStatusCode.Ok);
		}
		private string ReplaceMarkers(string content)
		{
			foreach (var item in this.viewBag)
			{
				content = content.Replace(ReplacementPreffix + item.Key, item.Value);
			}

			return content;
		}
		private string GetViewContent(string viewName, string controller)
		{
			var layoutContent = File.ReadAllText(LayoutPath);
			var content = File.ReadAllText(this.GetFilePath(viewName,controller));
			content = this.ReplaceMarkers(content);
			layoutContent = this.ReplaceMarkers(layoutContent);

			var allContent = layoutContent.Replace(ReplacementBodyText, content);
			return allContent;
		}
		
		private string GetFilePath(string viewName, string cotroller)
		{
			var controllerName = string.Empty;
			if (cotroller == "")
			{
				controllerName = this.GetCurrentControllerName();
			}
			else
			{
				controllerName = cotroller;
			}
			
			return $"{RootDirectoryRelativePath}{ViewFolderName}{DirectoryDelimeter}{controllerName}{DirectoryDelimeter}{viewName}{HtmlSuffix}";
		}
		private string GetCurrentControllerName()
		{
			return this.GetType().Name.Replace(ControllerDefaultName, string.Empty);
		}
	}
}
