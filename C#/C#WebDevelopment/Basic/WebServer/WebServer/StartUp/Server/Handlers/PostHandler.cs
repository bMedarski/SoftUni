using System;
using StartUp.Server.HTTP.Contracts;

namespace StartUp.Server.Handlers
{
    public class PostHandler:RequestHandler
    {

	    public PostHandler(Func<IHttpRequest, IHttpResponse> handlingFunc) : base(handlingFunc)
	    {
	    }
    }
}
