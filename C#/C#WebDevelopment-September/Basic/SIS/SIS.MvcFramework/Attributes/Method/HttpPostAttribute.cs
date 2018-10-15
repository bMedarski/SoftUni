namespace SIS.MvcFramework.Attributes.Method
{

	public class HttpPostAttribute : HttpMethodAttribute
	{
		public override bool IsValid(string requestMethod)
		{
			return requestMethod.ToUpper() == "POST";
		}
	}
}
