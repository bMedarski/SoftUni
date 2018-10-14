namespace SIS.MvcFramework.Attributes
{
	using System;

	public abstract class HttpMethodAttribute:Attribute
	{
		public abstract bool IsValid(string requestMethod);

	}
}
