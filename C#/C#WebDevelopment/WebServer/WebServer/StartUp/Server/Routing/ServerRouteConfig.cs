namespace StartUp.Server.Routing
{
	using Contracts;
	using Common;
	using Enums;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	public class ServerRouteConfig : IServerRouteConfig
	{
		public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> routes;

		public ServerRouteConfig(IAppRouteConfig appRouteConfig)
		{
			Validator.ThrowIfNull(appRouteConfig,nameof(appRouteConfig));

			this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

			foreach (var requestMethod in Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>())
			{
				this.routes[requestMethod] = new Dictionary<string, IRoutingContext>();
			}

			this.InitializeServerConfig(appRouteConfig);
		}

		public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes => this.routes;

		private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
		{

			foreach (var kvp in appRouteConfig.Routes)
			{
				foreach (var requestHandler in kvp.Value)
				{
					List<string> parameters = new List<string>();
					string parsedRegex = this.ParseRoute(requestHandler.Key, parameters);

					IRoutingContext routingContext = new RoutingContext(requestHandler.Value, parameters);

					this.Routes[kvp.Key].Add(parsedRegex, routingContext);
				}
			}
		}

		private string ParseRoute(string requestHandlerKey, List<string> parameters)
		{
			var parsedRegex = new StringBuilder();

			parsedRegex.Append("^");
			if (requestHandlerKey == "/")
			{
				parsedRegex.Append($"{requestHandlerKey}$");
				return parsedRegex.ToString();
			}
			string[] tokens = requestHandlerKey.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			this.ParseTokens(parameters, tokens, parsedRegex);

			return parsedRegex.ToString();

		}

		private void ParseTokens(List<string> parameters, string[] tokens, StringBuilder parsedRegex)
		{

			for (int idx = 0; idx < tokens.Length - 1; idx++)
			{
				string end = idx == tokens.Length - 1 ? "$" : "/";

				if (!tokens[idx].StartsWith("{") && !tokens[idx].EndsWith("}"))
				{
					parsedRegex.Append($"{tokens[idx]}{end}");
					continue;
				}

				string pattern = "<\\w+>";
				var regex = new Regex(pattern);
				var match = regex.Match(tokens[idx]);

				if (!match.Success)
				{
					continue;
				}

				string paramName = match.Groups[0].Value.Substring(1, match.Groups[0].Length - 2);
				parameters.Add(paramName);
				parsedRegex.Append($"{tokens[idx].Substring(1, tokens[idx].Length - 2)}{end}");
			}
		}
	}
}
