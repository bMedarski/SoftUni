namespace SIS.MvcFramework.Views
{
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using MvcFramework;

	public class ViewEngine
    {
        private const string DisplayTemplateSuffix = "DisplayTemplate";

        private const string DisplayTemplatesFolderName = "DisplayTemplates";

        private const string LayoutViewName = "_Layout";

	    private const string NavigationViewName = "_Navigation";

	    private const string FooterViewName = "_Footer";

        private const string ErrorViewName = "_Error";

        private const string ViewExtension = "html";

        private const string ModelCollectionViewParameterPattern = @"\@Model\.Collection\.(\w+)\((.+)\)";

        private string ViewsFolderPath =>
            $@"{MvcContext.Get.RootDirectoryRelativePath}/{MvcContext.Get.ViewsFolderName}";

        private string ViewsSharedFolderPath =>
            $@"{this.ViewsFolderPath}/{MvcContext.Get.SharedViewsFolderName}";

        private string ViewsDisplayTemplateFolderPath =>
            $@"{this.ViewsSharedFolderPath}/{DisplayTemplatesFolderName}";

        private string FormatLayoutViewPath() =>
            $@"{this.ViewsSharedFolderPath}/{MvcContext.Get.LayoutViewName}.{ViewExtension}";

	    private string FormatFooterViewPath() =>
		    $@"{this.ViewsSharedFolderPath}/{FooterViewName}.{ViewExtension}";

	    private string FormatNavigationViewPath() =>
		    $@"{this.ViewsSharedFolderPath}/{NavigationViewName}.{ViewExtension}";

        private string FormatErrorViewPath =>
            $@"{this.ViewsSharedFolderPath}/{ErrorViewName}.${ViewExtension}";

        private string FormatViewPath(string controllerName, string actionName) =>
            $@"{this.ViewsFolderPath}/{controllerName}/{actionName}.{ViewExtension}";

        private string FormatDisplayTemplatePath(string objectName)
            => $@"{this.ViewsDisplayTemplateFolderPath}/{objectName}{DisplayTemplateSuffix}.{ViewExtension}";

        private string ReadLayoutHtml(string viewPath)
        {
            if (!File.Exists(viewPath))
            {
                throw new FileNotFoundException($"Layout view could not be found");
            }

            return File.ReadAllText(viewPath);
        }
	    private string ReadNavigationHtml(string viewPath)
	    {
		    if (!File.Exists(viewPath))
		    {
			    throw new FileNotFoundException($"Navigation view could not be found");
		    }

		    return File.ReadAllText(viewPath);
	    }
	    private string ReadFooterHtml(string viewPath)
	    {
		    if (!File.Exists(viewPath))
		    {
			    throw new FileNotFoundException($"Footer view could not be found");
		    }

		    return File.ReadAllText(viewPath);
	    }
        private string ReadErrorHtml(string viewPath)
        {
            if (!File.Exists(viewPath))
            {
                throw new FileNotFoundException($"Error view could not be found");
            }

            return File.ReadAllText(viewPath);
        }

        private string ReadViewHtml(string viewPath)
        {
            if (!File.Exists(viewPath))
            {
                throw new FileNotFoundException($"View could not be found");
            }

            return File.ReadAllText(viewPath);
        }

        public string GetErrorContent()
            => this.ReadLayoutHtml(this.FormatLayoutViewPath())
                .Replace("@RenderError", this.ReadErrorHtml(this.FormatErrorViewPath));

        public string GetViewContent(string controller, string action)
            => this.ReadLayoutHtml(this.FormatLayoutViewPath())
				.Replace("@RenderFooter", this.ReadFooterHtml(this.FormatFooterViewPath()))
		        .Replace("@RenderNavigation", this.ReadNavigationHtml(this.FormatNavigationViewPath()))
                .Replace("@RenderBody", this.ReadViewHtml(this.FormatViewPath(controller, action)));

        public string RenderHtml(string fullHtmlContent, IDictionary<string, object> viewData)
        {
            string renderedHtml = fullHtmlContent;

            if (viewData.Count > 0)
            {
                foreach (var parameter in viewData)
                {
                    renderedHtml =
                        this.RenderViewData(renderedHtml, parameter.Value, parameter.Key);
                }


               
                if (viewData.ContainsKey("Error"))
                {
                    renderedHtml = renderedHtml.Replace(@"@Error", viewData["error"].ToString());
                }
            }

            return renderedHtml;
        }

        private string RenderViewData(
            string template,
            object viewObject,
            string viewObjectName = null)
        {
            if(viewObject != null &&
               viewObject.GetType() != typeof(string) &&
               viewObject is IEnumerable collectionProperty &&
               Regex.IsMatch(template, ModelCollectionViewParameterPattern))
            {
                Match collectionMatch = Regex.Matches(template, ModelCollectionViewParameterPattern)
                    .First(m => m.Groups[1].Value == viewObjectName);

                var fullMatch = collectionMatch.Groups[0].Value;
                var itemPattern = collectionMatch.Groups[2].Value;

                string result = string.Empty;

                foreach (var element in collectionProperty)
                {
                    result += itemPattern.Replace("@Item", this.RenderViewData(template, element));
                }

                return template.Replace(fullMatch, result);
            }

            if (viewObject != null &&
               !viewObject.GetType().IsPrimitive &&
               viewObject.GetType() != typeof(string))
            {
                var objectDisplayTemplate = this.FormatDisplayTemplatePath(viewObject.GetType().Name);
                if (File.Exists(objectDisplayTemplate))
                {
                    string renderedObject = this.RenderObject(viewObject,
                        File.ReadAllText(objectDisplayTemplate));

                    return viewObjectName != null
                        ? template.Replace($"@Model.{viewObjectName}", renderedObject)
                        : renderedObject;
                }
            }

            return viewObjectName != null
                ? template.Replace($"@Model.{viewObjectName}", viewObject?.ToString())
                : viewObject?.ToString();
        }

        private string RenderObject(object viewObject, string displayTemplate)
        {
            var viewObjectType = viewObject.GetType();
            var viewObjectProperties = viewObjectType.GetProperties();

            foreach (var viewObjectProperty in viewObjectProperties)
            {
                displayTemplate = this.RenderViewData(
                    displayTemplate,
                    viewObjectProperty.GetValue(viewObject),
                    viewObjectProperty.Name);
            }

            return displayTemplate;
        }
    }
}