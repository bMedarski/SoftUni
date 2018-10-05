namespace SIS.HTTP.Requests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Contracts;
	using Cookies;
	using Cookies.Contracts;
	using Enums;
	using Exceptions;
	using Extensions;
	using Headers;
	using Headers.Contracts;
	using HTTP.Common;
	using Sessions.Contracts;

	public class HttpRequest : IHttpRequest
	{

		public HttpRequest(string requestString)
		{
			this.FormData = new Dictionary<string, object>();
			this.QueryData = new Dictionary<string, object>();
			this.Headers = new HttpHeaderCollection();
			this.Cookies = new HttpCookiesCollection();

			this.ParseRequest(requestString);
		}
		public string Path { get; private set; }
		public string Url { get; private set; }
		public IDictionary<string, object> FormData { get; }
		public IDictionary<string, object> QueryData { get; }
		public IHttpHeaderCollection Headers { get; }
		public IHttpCookiesCollection Cookies { get; }
		public HttpRequestMethod RequestMethod { get; private set; }
		public IHttpSession Session { get; set; }
		public void ParseRequest(string requestString)
		{
			//Spliting request by new line
			string[] splitRequestContent =
				requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

			//Spliting request line by space
			string[] requestLine = splitRequestContent[0].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			if (!this.IsValidRequestLine(requestLine))
			{
				throw new BadRequestException(RequestConstants.InvalidRequestLineMessage);
			}

			this.ParseRequestMethod(requestLine);
			this.ParseRequestUrl(requestLine);
			this.ParseRequestPath();

			this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
			this.ParseCookies();
			this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);

		}

		private void ParseCookies()
		{
			if (!this.Headers.ContainsHeader(GlobalConstants.CookiesHeaderKey))
			{
				return;
			}

			var cookies = this.Headers.GetHeader(GlobalConstants.CookiesHeaderKey).Value.Trim().Split(GlobalConstants.HttpCookieStringDelimiter,StringSplitOptions.RemoveEmptyEntries);
			foreach (var cookie in cookies)
			{
				var cookiesParts = cookie.Split(GlobalConstants.HttpCookieKeyValueDelimiter,2);
				var cookieKey = cookiesParts[0];
				var cookieValue = cookiesParts[1];

				var httpCookie = new HttpCookie(cookieKey,cookieValue,false);
				this.Cookies.Add(httpCookie);
			}
		}

		private bool IsValidRequestLine(string[] requestLine)
		{
			if (requestLine.Length != RequestConstants.RequestLinePartsCount || requestLine[2] != GlobalConstants.HttpOneProtocolFragment)
			{
				return false;
			}
			return true;
		}
		private void ParseRequestMethod(string[] requestLine)
		{
			var requestMethod = requestLine[0].ToLower().Capitalize();

			HttpRequestMethod method;
			try
			{
				method = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), requestMethod);
			}
			catch (Exception)
			{
				throw new BadRequestException(RequestConstants.InvalidRequestMethodMessage);
			}
			this.RequestMethod = method;
		}
		private void ParseRequestUrl(string[] requestLine)
		{

			this.Url = requestLine[1];

		}

		private void ParseRequestPath()
		{
			Console.WriteLine("=",20);
			Console.WriteLine(this.Url.Split(new[] { RequestConstants.QueryDelimiter }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower());
			this.Path = this.Url.Split(new[] { RequestConstants.QueryDelimiter }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
		}
		private void ParseHeaders(string[] requestContent)
		{
			foreach (var headerLine in requestContent)
			{
				if (headerLine == "")
				{
					break;
				}

				var headerArgs = headerLine.Split(GlobalConstants.HeaderDelimeter,StringSplitOptions.RemoveEmptyEntries);

				if (headerArgs.Length != RequestConstants.NumberOfParametersInRequestHeaderKeyValuePair)
				{
					throw new BadRequestException(RequestConstants.InvalidNumberOfParametersInRequestHeaderKeyValuePair);
				}

				var headerKey = headerArgs[0];
				var headerValue = headerArgs[1];

				Validator.ThrowIfNullOrEmpty(headerKey,nameof(headerKey));
				Validator.ThrowIfNullOrEmpty(headerValue,nameof(headerValue));

				var header = new HttpHeader(headerKey, headerValue);
				this.Headers.Add(header);

				if (!this.Headers.ContainsHeader(RequestConstants.HostHeaderKey))
				{
					throw new BadRequestException(RequestConstants.MissingHostHeaderMessage);
				}
			}
		}

		private void ParseQueryParameters()
		{
			if (!this.Url.Contains(RequestConstants.QueryDelimiter))
			{
				return;
			}

			var query = this.Url.
				Split(new[] { RequestConstants.QueryDelimiter, RequestConstants.FragmentDelimiter }, StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			if (query.Length == 1)
			{
				return;
			}

			this.ProccessParameters(this.QueryData,query[1]);
		}

		private void ProccessParameters(IDictionary<string,object> dataContainer,string query)
		{
			Validator.ThrowIfNullOrEmpty(query,nameof(query));

			var parameters = query.Split(new[] {RequestConstants.ParameterDelimiter}, StringSplitOptions.RemoveEmptyEntries);

			foreach (var kvp in parameters)
			{
				var keyValuePair = kvp.Split(new[] {RequestConstants.KeyValuePairsDelimiter }, StringSplitOptions.RemoveEmptyEntries);

				if (keyValuePair.Length != RequestConstants.NumberOfPartsOfKeyValuePair)
				{
					throw new BadRequestException(RequestConstants.InvalidNumberOfPartsOfKeyValuePair);
				}

				var parameterKey = keyValuePair[0];
				var parameterValue = keyValuePair[1];

				Validator.ThrowIfNullOrEmpty(parameterKey,nameof(parameterKey));
				Validator.ThrowIfNullOrEmpty(parameterKey,nameof(parameterValue));

				dataContainer[parameterKey] = parameterValue;
			}
		}
		private void ParseFormDataParameters(string formData)
		{
			if (formData == "")
			{
				return;
			}
			this.ProccessParameters(this.FormData,formData);
		}
		private void ParseRequestParameters(string formData)
		{
			this.ParseQueryParameters();
			this.ParseFormDataParameters(formData);
		}
	}
}
