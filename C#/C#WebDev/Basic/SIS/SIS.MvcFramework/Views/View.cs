namespace SIS.MvcFramework.Views
{
	using System.IO;
	using ActionResults.Contracts;

	public class View : IRenderable
	{
		private readonly string fullyQualifiedTemplateName;

		public View(string fullyQualifiedTemplateName)
		{
			this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
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
			var fullHtml = this.ReadFile();
			return fullHtml;
		}
	}
}
