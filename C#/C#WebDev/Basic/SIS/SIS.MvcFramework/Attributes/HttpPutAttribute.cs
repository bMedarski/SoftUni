﻿namespace SIS.MvcFramework.Attributes
{
	public class HttpPutAttribute : HttpMethodAttribute
	{
		public override bool IsValid(string requestMethod)
		{
			return requestMethod.ToUpper() == "PUT";
		}
	}
}
