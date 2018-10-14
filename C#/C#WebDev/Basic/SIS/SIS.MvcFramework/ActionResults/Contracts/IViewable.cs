namespace SIS.MvcFramework.ActionResults.Contracts
{
	public interface IViewable : IActionResult
	{
		IRenderable View { get; set; }
	}
}
