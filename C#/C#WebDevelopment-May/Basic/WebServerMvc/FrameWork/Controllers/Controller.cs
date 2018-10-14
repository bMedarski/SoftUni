using System.Runtime.CompilerServices;
using FrameWork.Interfaces;
using FrameWork.Interfaces.Generic;
using FrameWork.ViewEngine;
using FrameWork.ViewEngine.Generic;

namespace FrameWork.Controllers
{
    public class Controller
    {
	    protected IActionResult View([CallerMemberName] string caller="")
	    {
		    string controllerName = this.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);

		    string fullQualifiedNAme = string.Format(
			    "{0}.{1}.{2}.{3}, {0}",
			    MvcContext.Get.AssemblyName,
			    MvcContext.Get.ViewsFolder,
			    controllerName,
			    caller);
			return new ActionResult(fullQualifiedNAme);
	    }

	    protected IActionResult View(string controller, string action)
	    {
			string fullQualifiedNAme = string.Format(
			    "{0}.{1}.{2}.{3}, {0}",
			    MvcContext.Get.AssemblyName,
			    MvcContext.Get.ViewsFolder,
			    controller,
				action);
		    return new ActionResult(fullQualifiedNAme);
		}
	    protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
	    {
		    string controllerName = this.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);

		    string fullQualifiedNAme = string.Format(
			    "{0}.{1}.{2}.{3}, {0}",
			    MvcContext.Get.AssemblyName,
			    MvcContext.Get.ViewsFolder,
			    controllerName,
			    caller);
		    return new ActionResult<T>(fullQualifiedNAme,model);
	    }
		protected IActionResult<T> View<T>(T model,string controller, string action)
		{
			string fullQualifiedNAme = string.Format(
				"{0}.{1}.{2}.{3}, {0}",
				MvcContext.Get.AssemblyName,
				MvcContext.Get.ViewsFolder,
				controller,
				action);
			return new ActionResult<T>(fullQualifiedNAme,model);
		}
	}
}
