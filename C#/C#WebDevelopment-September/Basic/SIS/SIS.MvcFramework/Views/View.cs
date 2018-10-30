namespace SIS.MvcFramework.Views
{
	using ActionResults.Contracts;

	public class View : IRenderable
    {
        private const string RenderBodyConstant = "@RenderBody()";

        private readonly string fullHtmlContent;

        public View(string fullHtmlContent)
        {
            this.fullHtmlContent = fullHtmlContent;
        }

        public string Render() => this.fullHtmlContent;
    }
}