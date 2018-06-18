namespace StartUp.Server.HTTP.Response
{
	using Enums;
	using Exceptions;
	using Server.Contracts;
	
	public class ViewResponse : HttpResponse
    {
	    private readonly IView view;

		public ViewResponse(HttpStatusCode responseCode, IView view)
		{
			ValidateStatusCode();

		    this.view = view;
		    this.StatusCode = responseCode;
		}

	    private void ValidateStatusCode()
	    {
		    var statusCode = (int) this.StatusCode;
		    if (299 < statusCode && statusCode > 400)
		    {
			    throw new InvalidResponseException("Status code must be between 300 and 400");
		    }
	    }

	    public override string ToString()
	    {
		    return $"{base.ToString()}{this.view.View()}";
	    }
    }
}
