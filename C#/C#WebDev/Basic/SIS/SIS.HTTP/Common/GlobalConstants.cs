namespace SIS.HTTP.Common
{
	public static class GlobalConstants
	{
		public const string HttpOneProtocolFragment = "HTTP/1.1";
		public const string CookiesHeaderKey = "Cookie";
		public const string SessionCookieKey = "SIS_ID";
		public const string HttpCookieStringDelimiter = "; ";
		public const char HttpCookieKeyValueDelimiter = '=';
		public const string HeaderDelimiter = ": ";
		public static string[] PermittedResourceExtensions = new[] {"js", "css","ico","map"};
	}
}
