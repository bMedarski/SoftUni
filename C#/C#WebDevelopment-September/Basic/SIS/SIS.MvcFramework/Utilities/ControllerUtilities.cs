namespace SIS.MvcFramework.Utilities
{
	using System;

	public static class ControllerUtilities
	{
		public static string GetControllerName(object controllerName)
			=> controllerName.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);

		public static string GetViewFullyQualifiedName(string controllerName, string actionName)
			=> $@"../../../{MvcContext.Get.ViewsFolder}/{controllerName}/{actionName}.html";

	}
}
