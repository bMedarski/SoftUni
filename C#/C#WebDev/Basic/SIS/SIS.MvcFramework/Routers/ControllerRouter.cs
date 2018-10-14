namespace SIS.MvcFramework.Routers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using ActionResults.Contracts;
	using Attributes;
	using Controllers;
	using HTTP.Enums;
	using HTTP.Requests.Contracts;
	using HTTP.Responses;
	using HTTP.Responses.Contracts;
	using WebServer.Api;
	using WebServer.Results;

	public class ControllerRouter:IHttpHandler
	{
		private readonly ResourceHandler resourceHandler;

		public ControllerRouter()
		{
			this.resourceHandler = new ResourceHandler();
		}
		public IHttpResponse Handle(IHttpRequest request)
		{

			if (this.resourceHandler.ReturnIfResource(request.Path))
			{
				return this.resourceHandler.HandleResourceRequest(request);
			}

			var controllerName = string.Empty;
			var actionName = string.Empty;
			var requestMethod = request.RequestMethod.ToString();

			if (request.Url == "/")
			{
				controllerName = "Home";
				actionName = "Index";
			}
			else
			{
				var requestUrlSplit = request.Url.Split(
					"/",
					StringSplitOptions.RemoveEmptyEntries);
                
				controllerName = requestUrlSplit[0];
				actionName = requestUrlSplit[1];
			}

			var controller = this.GetController(controllerName, request);
			var action = this.GetAction(requestMethod, controller, actionName);
			if (action == null)
			{
				return new HttpResponce(HttpResponseStatusCode.NotFound);
			}

			if (controller == null)
			{
				throw new NullReferenceException("No such controller");
			}
			return this.PrepareResponse(controller, action);

		}

		private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
		{
			IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
			string invocationResult = actionResult.Invoke();

			if (actionResult is IViewable)
			{
				return new HtmlResult(invocationResult,HttpResponseStatusCode.Ok);
			}
			else if (actionResult is IRedirectable)
			{
				return new RedirectResult(invocationResult);
			}
			else
			{
				throw new InvalidOperationException("The View result is not supported");
			}
		}

		private Controller GetController(string controllerName, IHttpRequest request)
		{
			if (controllerName != null)
			{
				var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
					MvcContext.Get.AssemblyName,
					MvcContext.Get.ControllersFolder,
					controllerName,
					MvcContext.Get.ControllersSuffix);

				var controllerType = Type.GetType(fullyQualifiedControllerName);
				var controller = (Controller) Activator.CreateInstance(controllerType);

				if (controller != null)
				{
					controller.Request = request;
				}

				return controller;
			}

			return null;
		}

		private MethodInfo GetAction(string requestMethod, Controller controller, string actionName)
		{
			MethodInfo method = null;
			var actions = this.GetSuitableMethods(controller, actionName);

			if (!actions.Any())
			{
				return null;
			}

			foreach (var action in actions)
			{
				var attributes = action.GetCustomAttributes().Where(attr => attr is HttpMethodAttribute)
					.Cast<HttpMethodAttribute>();

				if (!attributes.Any()&&requestMethod.ToUpper()=="GET")
				{
					return action;
				}

				foreach (var attribute in attributes)
				{
					if (attribute.IsValid(requestMethod))
					{
						return action;
					}
				}
			}

			return method;
		}

		private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
		{
			if (controller == null)
			{
				return new MethodInfo[0];
			}

			return controller.GetType().GetMethods()
				.Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());
		}
	}
}
