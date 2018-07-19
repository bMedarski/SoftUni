using System.Text;
using StartUp.Server.Enums;
using StartUp.Server.HTTP.Contracts;

namespace StartUp.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
	    private string StatusCodeMessage => this.StatusCode.ToString();

		protected HttpResponse()
	    {
		    this.HeaderCollection = new HttpHeaderCollection();
	    }

	    public IHttpHeaderCollection HeaderCollection { get;}
		public HttpStatusCode StatusCode { get; protected set; }

	    public override string ToString()
	    {
		    var response = new StringBuilder();

		    var statusCodeNumber = (int)this.StatusCode;
		    response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusCodeMessage}");

		    response.AppendLine(this.HeaderCollection.ToString());

		    return response.ToString();
	    }
	}
}
