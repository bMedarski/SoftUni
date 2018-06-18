using System;
using StartUp.Server.HTTP.Contracts;

namespace StartUp.Server.Handlers
{
    public class GetHandler:RequestHandler
    {
	    public GetHandler(Func<IHttpRequest, IHttpResponse> handlingFunc) : base(handlingFunc)
	    {
	    }
    }
}
