namespace StartUp.Server.HTTP
{
	using Contracts;

    public class HttpContext : IHttpContext
    {

	    private readonly IHttpRequest request;

	    public HttpContext(string requestString)
	    {
		    this.request = new HttpRequest(requestString);
	    }

	    public IHttpRequest Request => this.request;
    }
}
