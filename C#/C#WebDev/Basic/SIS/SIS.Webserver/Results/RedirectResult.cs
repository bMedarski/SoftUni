namespace SIS.WebServer.Results
{
	using HTTP.Enums;
	using HTTP.Headers;
	using HTTP.Responses;

	public class RedirectResult: HttpResponce
    {
	    private const string ContentTypeHeaderKey = "Location";
	    public RedirectResult(string location)
			:base(HttpResponseStatusCode.SeeOther)
	    {
		    this.Headers.Add(new HttpHeader(ContentTypeHeaderKey,location));
	    }
    }
}
