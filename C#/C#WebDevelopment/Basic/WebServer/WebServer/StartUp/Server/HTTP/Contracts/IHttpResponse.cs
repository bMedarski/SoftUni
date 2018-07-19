namespace StartUp.Server.HTTP.Contracts
{
	using Enums;

    public interface IHttpResponse
    {
	    HttpStatusCode StatusCode { get;}
	    IHttpHeaderCollection HeaderCollection { get; }
	}
}
