using System;

namespace StartUp.Server.HTTP.Response
{
	using Common;
	using Enums;

    public class RedirectResponse : HttpResponse
    {
	    public RedirectResponse(string redirectRoute)
	    {
		    Validator.ThrowIfNullOrEmpty(redirectRoute, nameof(redirectRoute));
		    this.StatusCode = HttpStatusCode.Found;
		    this.HeaderCollection.Add(HttpHeader.Location, redirectRoute);
		}
    }
}
