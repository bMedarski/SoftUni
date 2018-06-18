namespace StartUp.Server.HTTP
{
	using Common;
	using Contracts;
	using Enums;
	using Exceptions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;

	public class HttpRequest : IHttpRequest
	{
		private readonly string requestText;

		public HttpRequest(string requestText)
		{
			Validator.ThrowIfNullOrEmpty(requestText, nameof(requestText));

			this.requestText = requestText;

			this.FormData = new Dictionary<string, string>();
			this.QueryParameters = new Dictionary<string, string>();
			this.UrlParameters = new Dictionary<string, string>();
			this.HeaderCollection = new HttpHeaderCollection();
			//this.Cookies = new HttpCookieCollection();

			this.ParseRequest(requestText);
		}

		public IDictionary<string, string> FormData { get; private set; }

		public IHttpHeaderCollection HeaderCollection { get; private set; }

		//public IHttpCookieCollection Cookies { get; private set; }

		public string Path { get; private set; }

		public IDictionary<string, string> QueryParameters { get; private set; }

		public HttpRequestMethod RequestMethod { get; private set; }

		public string Url { get; private set; }

		public IDictionary<string, string> UrlParameters { get; private set; }

		//public IHttpSession Session { get; set; }

		public void AddUrlParameter(string key, string value)
		{
			Validator.ThrowIfNullOrEmpty(key, nameof(key));
			Validator.ThrowIfNullOrEmpty(value, nameof(value));

			this.UrlParameters[key] = value;
		}

		private void ParseRequest(string requestText)
		{
			var requestLines = requestText.Split(Environment.NewLine);

			if (!requestLines.Any())
			{
				BadRequestException.ThrowFromInvalidRequest();
			}

			var requestLine = requestLines.First().Split(
				new[] { ' ' },
				StringSplitOptions.RemoveEmptyEntries);

			if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
			{
				BadRequestException.ThrowFromInvalidRequest();
			}

			this.RequestMethod = this.ParseMethod(requestLine.First());
			this.Url = requestLine[1];
			this.Path = this.ParsePath(this.Url);

			this.ParseHeaders(requestLines);
			this.ParseCookies();
			this.ParseParameters();
			this.ParseFormData(requestLines.Last());

			//this.SetSession();
		}

		private HttpRequestMethod ParseMethod(string method)
		{
			HttpRequestMethod parsedMethod;
			if (!Enum.TryParse(method, true, out parsedMethod))
			{
				BadRequestException.ThrowFromInvalidRequest();
			}

			return parsedMethod;
		}

		private string ParsePath(string url)
			=> url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

		private void ParseHeaders(string[] requestLines)
		{
			var emptyLineAfterHeadersIndex = Array.IndexOf(requestLines, string.Empty);

			for (int i = 1; i < emptyLineAfterHeadersIndex; i++)
			{
				var currentLine = requestLines[i];
				var headerParts = currentLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

				if (headerParts.Length != 2)
				{
					BadRequestException.ThrowFromInvalidRequest();
				}

				var headerKey = headerParts[0];
				var headerValue = headerParts[1].Trim();

				var header = new HttpHeader(headerKey, headerValue);

				this.HeaderCollection.Add(header);
			}

			if (!this.HeaderCollection.ContainsKey(HttpHeader.Host))
			{
				BadRequestException.ThrowFromInvalidRequest();
			}
		}

		private void ParseCookies()
		{
			if (this.HeaderCollection.ContainsKey(HttpHeader.Cookie))
			{
				var allCookies = this.HeaderCollection.Get(HttpHeader.Cookie);

				foreach (var cookie in allCookies)
				{
					if (!cookie.Value.Contains('='))
					{
						return;
					}

					var cookieParts = cookie
						.Value
						.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
						.ToList();

					if (!cookieParts.Any())
					{
						continue;
					}

					foreach (var cookiePart in cookieParts)
					{
						var cookieKeyValuePair = cookiePart
							.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

						if (cookieKeyValuePair.Length == 2)
						{
							var key = cookieKeyValuePair[0].Trim();
							var value = cookieKeyValuePair[1].Trim();

							//this.Cookies.Add(new HttpCookie(key, value, false));
						}
					}
				}
			}
		}

		private void ParseParameters()
		{
			if (!this.Url.Contains('?'))
			{
				return;
			}

			var query = this.Url
				.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)
				.Last();

			this.ParseQuery(query, this.UrlParameters);
		}

		private void ParseFormData(string formDataLine)
		{
			if (this.RequestMethod == HttpRequestMethod.Get)
			{
				return;
			}

			this.ParseQuery(formDataLine, this.FormData);
		}

		private void ParseQuery(string query, IDictionary<string, string> dict)
		{
			if (!query.Contains('='))
			{
				return;
			}

			var queryPairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var queryPair in queryPairs)
			{
				var queryKvp = queryPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

				if (queryKvp.Length != 2)
				{
					return;
				}

				var queryKey = WebUtility.UrlDecode(queryKvp[0]);
				var queryValue = WebUtility.UrlDecode(queryKvp[1]);

				dict.Add(queryKey, queryValue);
			}
		}


		public override string ToString() => this.requestText;
	}
}
