namespace SIS.MvcFramework.Controllers
{
	using System.Runtime.CompilerServices;
	using ActionResults;
	using ActionResults.Contracts;
	using HTTP.Requests.Contracts;
	using Utilities;
	using Views;

	public abstract class Controller
	{
		public IHttpRequest Request { get; set; }

		protected IViewable View([CallerMemberName] string viewName = "")
		{
			var controllerName = ControllerUtilities.GetControllerName(this);
			var fullyQualifiedName = ControllerUtilities.GetViewFullyQualifiedName(controllerName, viewName);
			var view = new View(fullyQualifiedName);
			return new ViewResult(view);
		}

		protected IRedirectable RedirectToAction(string redirectUrl)=>new RedirectResult(redirectUrl);
	}
}
