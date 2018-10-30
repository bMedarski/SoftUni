namespace SIS.MvcFramework.Utilities
{
	public static class ControllerUtilities
	{
		public static string GetControllerName(object controllerName)
			=> controllerName.GetType().Name.Replace(MvcContext.Get.ControllerSuffix, string.Empty);

		public static string GetViewFullyQualifiedName(string controllerName, string actionName)
			=> $@"../../../{MvcContext.Get.ViewsFolderName}/{controllerName}/{actionName}.html";

	}
}
