namespace SIS.MvcFramework.Views
{
	using System.Collections.Generic;
	using System.IO;
	using ActionResults.Contracts;

	public class View : IRenderable
	{
		private readonly string fullyQualifiedTemplateName;
		private readonly IDictionary<string, object> viewData;

		public View(string fullyQualifiedTemplateName, IDictionary<string,object> viewData)
		{
			this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
			this.viewData = viewData;
		}

		private string ReadFile()
		{
			if (!File.Exists(this.fullyQualifiedTemplateName))
			{
				throw new FileNotFoundException($"View does not exist at {this.fullyQualifiedTemplateName}");
			}

			return File.ReadAllText(this.fullyQualifiedTemplateName);
		}

		public string Render()
		{
			string fullHtml = this.ReadFile();
			string renderedHtml = this.RenderHtml(fullHtml);
			return renderedHtml;
		}

		private string RenderHtml(string fullHtml)
		{
			string renderedHtml = fullHtml;

			foreach (var item in this.viewData)
			{
				renderedHtml = renderedHtml.Replace($"{{{{{item}}}}}",item.Value.ToString());
			}

			return renderedHtml;
		}
	}
}
