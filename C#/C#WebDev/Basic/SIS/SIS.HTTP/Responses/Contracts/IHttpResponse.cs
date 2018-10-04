namespace SIS.HTTP.Responses.Contracts
{
	using Cookies;
	using Enums;
	using Headers;
	using Headers.Contracts;

	public interface IHttpResponse
    {
		HttpResponseStatusCode StatusCode { get; set; }
		IHttpHeaderCollection Headers { get; }
		byte[] Content { get; set; }
	    void AddHeader(HttpHeader header);
	    void AddCookie(HttpCookie cookie);
	    byte[] GetBytes();
    }
}
