using System;
using StartUp.Application.Views;
using StartUp.Server;
using StartUp.Server.Enums;
using StartUp.Server.HTTP.Contracts;
using StartUp.Server.HTTP.Response;

namespace StartUp.Application.Controllers
{
    public class UserController
    {
	    public IHttpResponse RegisterGet()
	    {
		    return new ViewResponse(HttpStatusCode.OK, new RegisterView());
	    }

	    public IHttpResponse RegisterPost(string name)
	    {
		    Console.WriteLine("vlizam-------------------------------------------------");
			return new RedirectResponse($"/user/{name}");
	    }
	    public IHttpResponse Details(string name)
	    {
		    var model = new Model();
		    model[name] = name;
		    return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
	    }
	}
}
