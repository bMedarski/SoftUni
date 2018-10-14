namespace SIS.WebServer.Routing
{
	using System;
	using System.Collections.Generic;
	using Contracts;
	using HTTP.Common;
	using HTTP.Enums;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;

	public class ServerRoutingTable:IServerRoutingTable
    {
	    public ServerRoutingTable()
	    {
		    this.Routes = new Dictionary<HttpRequestMethod, IDictionary<string, Func<IHttpRequest, IHttpResponse>>>()
		    {
				[HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
			    [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
			    [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
			    [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
		    };
	    }

	    private IDictionary<HttpRequestMethod, IDictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; }

	    public void Add(HttpRequestMethod method, string path, Func<IHttpRequest,IHttpResponse> action)
	    {
			Validator.ThrowIfNullOrEmpty(path,nameof(path));
			Validator.ThrowIfNullOrEmpty(method.ToString(),nameof(method));
			Validator.ThrowIfNull(action,nameof(action));

			var route = new Func<IHttpRequest, IHttpResponse>(action);
			this.Routes[method].Add(path.ToLower(), route);
	    }

	    public void AddGet(string path, Func<IHttpRequest,IHttpResponse> action)
	    {
		    var route = new Func<IHttpRequest, IHttpResponse>(action);
		    this.Routes[HttpRequestMethod.Get].Add(path.ToLower(), route);
	    }
	    public void Post(string path, Func<IHttpRequest,IHttpResponse> action)
	    {
		    var route = new Func<IHttpRequest, IHttpResponse>(action);
		    this.Routes[HttpRequestMethod.Post].Add(path.ToLower(), route);
	    }
	    public bool ContainsMethod(HttpRequestMethod method)
	    {
		    Validator.ThrowIfNullOrEmpty(method.ToString(),nameof(method));
		    return this.Routes.ContainsKey(method);
	    }

	    public bool ContainsPath(HttpRequestMethod method,string path)
	    {
		    Validator.ThrowIfNullOrEmpty(method.ToString(),nameof(method));
		    Validator.ThrowIfNullOrEmpty(path,nameof(path));
		    return this.Routes[method].ContainsKey(path);
	    }

	    public Func<IHttpRequest, IHttpResponse> GetFunction(HttpRequestMethod method, string path)
	    {
		    Validator.ThrowIfNullOrEmpty(path,nameof(path));
		    Validator.ThrowIfNullOrEmpty(method.ToString(),nameof(method));
		    return this.Routes[method][path];
	    }
    }
}
