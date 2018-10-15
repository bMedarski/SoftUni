namespace IRuneWebApp.Extensions
{
	using System.Net;

	public static class StringExtensions
	{
		public static string Decode(this string text)
		{
			return WebUtility.UrlDecode(text);
		}
	}
}
