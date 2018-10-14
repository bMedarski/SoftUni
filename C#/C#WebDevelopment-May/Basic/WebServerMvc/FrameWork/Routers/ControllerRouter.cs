using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FrameWork.Attributes.Methods;
using FrameWork.Helpers;
using WebServer.Contracts;
using WebServer.Exceptions;
using WebServer.Http.Contracts;

namespace FrameWork.Routers
{
    public class ControllerRouter:IHandleable
    {
	    private IDictionary<string, string> getParams;
	    private IDictionary<string, string> postParams;
	    private string requestMethod;
	    private string controllerName;
	    private string actionName;
	    private object[] methodParams;

		public IHttpResponse Handle(IHttpRequest request)
		{
			this.getParams = new Dictionary<string, string>(request.UrlParameters);
			this.postParams = new Dictionary<string, string>(request.FormData);
			this.requestMethod = request.Method.ToString().ToUpper();

			this.PrepareControllerAnDActionNames(request);
			var method = GetActionForExecution();
			this.PrepareMethodParameters(method);

			return null;
		}

	    private void PrepareControllerAnDActionNames(IHttpRequest request)
	    {
		    var paths = request.Path.Split(new[] {'/', '?'},StringSplitOptions.RemoveEmptyEntries);

		    if (paths.Length < 2)
		    {
			    if (request.Path == "/")
			    {
				    this.controllerName = "HomeController";
				    this.actionName = "Index";

				    return;
			    }
			    else
			    {
				    BadRequestException.ThrowFromInvalidRequest();
			    }
		    }
		    this.controllerName = $"{paths[0].Capitalize()}{MvcContext.Get.ControllersSuffix}";
			this.actionName = paths[1].Capitalize();
	    }

	    private MethodInfo GetActionForExecution()
	    {
		    MethodInfo method = null;
		    foreach (var methodInfo in this.GetSuitableMethods())
		    {
			    IEnumerable<Attribute> attributes = methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);
			    if (!attributes.Any() && this.requestMethod == "GET")
			    {
				    return methodInfo;
			    }
			    foreach (HttpMethodAttribute attribute in attributes)
			    {
				    if (attribute.isValid(this.requestMethod))
				    {
					    return methodInfo;
				    }
			    }

		    }

		    return method;
	    }

	    private IEnumerable<MethodInfo> GetSuitableMethods()
	    {
		    var controller = this.GetControllerInstance();
		    if (controller == null)
		    {
			    return new MethodInfo[0];
		    }

		    return controller.GetType().GetMethods().Where(m => m.Name == this.actionName);
	    }

	    private object GetControllerInstance()
	    {
		    var controllerFullQualifiedName = string.Format(
			    "{0}.{1}.{2}.{3}, {0}",
				MvcContext.Get.AssemblyName,
				MvcContext.Get.ControllersFolder,
				this.controllerName);

		    var controllerType = Type.GetType(controllerFullQualifiedName);
		    if (controllerType==null)
		    {
			    return null;
		    }

		    return Activator.CreateInstance(controllerType);
	    }
	    private void PrepareMethodParameters(MethodInfo method)
	    {
		    var parameters = method.GetParameters();
			
			this.methodParams = new object[parameters.Length];

		    int index = 0;

		    foreach (var parameter in parameters)
		    {
			    if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
			    {
				    object value = this.getParams[parameter.Name];

				    this.methodParams[index] = Convert.ChangeType(
					    value,
					    parameter.ParameterType);
				    index++;
			    }
			    else
			    {
				    Type bindingModelType = parameter.ParameterType;
				    object bindingModel = Activator.CreateInstance(bindingModelType);

				    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

				    foreach (var property in properties)
				    {
					    property.SetValue(
							bindingModel,
							Convert.ChangeType(
								this.postParams[property.Name],
								property.PropertyType));
				    }
				    this.methodParams[index] = Convert.ChangeType(
					    bindingModel,
					    bindingModelType);
				    index++;
			    }
		    }
	    }
	}
}
