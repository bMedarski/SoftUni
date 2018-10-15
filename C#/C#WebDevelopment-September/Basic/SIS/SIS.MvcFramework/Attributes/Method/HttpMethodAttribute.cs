namespace SIS.MvcFramework.Attributes.Method
{
	using System;

	public abstract class HttpMethodAttribute:Attribute
	{
		public abstract bool IsValid(string requestMethod);

	}
}
