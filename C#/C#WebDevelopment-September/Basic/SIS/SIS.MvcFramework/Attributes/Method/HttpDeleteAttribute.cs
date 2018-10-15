namespace SIS.MvcFramework.Attributes.Method
{
	public class HttpDeleteAttribute : HttpMethodAttribute
	{
		public override bool IsValid(string requestMethod)
		{
			return requestMethod.ToUpper() == "DELETE";
		}
	}
}
