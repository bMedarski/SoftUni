namespace SIS.MvcFramework.ActionResults.Contracts
{
	public interface IRedirectable:IActionResult
	{
		string RedirectUrl { get; }
	}
}
