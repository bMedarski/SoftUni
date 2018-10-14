namespace SIS.MvcFramework.Attributes
{
	public class HttpGetAttribute : HttpMethodAttribute
	{
		public override bool IsValid(string requestMethod)
		{
			return requestMethod.ToUpper() == "GET";
		}
	}
}
