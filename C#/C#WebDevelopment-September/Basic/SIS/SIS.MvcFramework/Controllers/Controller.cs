namespace SIS.MvcFramework.Controllers
{
	using System.Runtime.CompilerServices;
	using ActionResults;
	using ActionResults.Contracts;
	using HTTP.Requests.Contracts;
	using Models;
	using Utilities;
	using Views;

	public abstract class Controller
	{

		protected Controller()
		{
			this.Model = new ViewModel();
		}

		protected ViewModel Model { get; set; }
		public IHttpRequest Request { get; set; }

		protected IViewable View([CallerMemberName] string viewName = "")
		{
			var controllerName = ControllerUtilities.GetControllerName(this);
			var fullyQualifiedName = ControllerUtilities.GetViewFullyQualifiedName(controllerName, viewName);


			var view = new View(fullyQualifiedName,this.Model.Data);
			return new ViewResult(view);
		}

		protected IRedirectable RedirectToAction(string redirectUrl)=>new RedirectResult(redirectUrl);
	}
}
