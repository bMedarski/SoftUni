namespace SIS.Webserver.Routing.Contracts
{
	using System;
	using HTTP.Enums;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;

	public interface IServerRoutingTable
	{
		void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> action);

		bool ContainsMethod(HttpRequestMethod method);

		bool ContainsPath(HttpRequestMethod method,string path);

		Func<IHttpRequest, IHttpResponse> GetFunction(HttpRequestMethod method, string path);
	}
}
