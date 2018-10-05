namespace SIS.HTTP.Cookies.Contracts
{
	using System.Collections.Generic;

	public interface IHttpCookiesCollection:IEnumerable<HttpCookie>
	{
		void Add(HttpCookie cookie);
		HttpCookie GetCookie(string key);
		bool ContainsCookie(string key);
		bool HasCookies();
		bool IfCookieIsNew(string key, string value);
	}
}
