namespace StartUp.Server.Routing.Contracts
{
	using System.Collections.Generic;
	using Enums;
	using Handlers.Contracts;

	public interface IAppRouteConfig
	{
		IDictionary<HttpRequestMethod, IDictionary<string, IRequestHandler>> Routes { get; }

		void AddRoute(string route, IRequestHandler httpHandler);
	}
}
