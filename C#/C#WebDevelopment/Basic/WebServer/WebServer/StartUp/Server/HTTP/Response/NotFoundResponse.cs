namespace StartUp.Server.HTTP.Response
{
	using Enums;

    public class NotFoundResponse:HttpResponse
    {
	    public NotFoundResponse()
	    {
		    this.StatusCode = HttpStatusCode.NotFound;
	    }
    }
}
