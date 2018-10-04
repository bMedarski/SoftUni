namespace SIS.HTTP.Requests.Contracts
{
	using Enums;
	using Headers.Contracts;
	using System.Collections.Generic;
	using Cookies.Contracts;
	using Sessions.Contracts;

	public interface IHttpRequest
    {
		string Path { get; }
		string Url { get; }
		IDictionary<string,object> FormData { get; }
	    IDictionary<string,object> QueryData { get; }
		IHttpHeaderCollection Headers { get; }
	    IHttpCookiesCollection Cookies { get; }
		HttpRequestMethod RequestMethod { get; }
	    IHttpSession Session { get; set; }
    }
}
