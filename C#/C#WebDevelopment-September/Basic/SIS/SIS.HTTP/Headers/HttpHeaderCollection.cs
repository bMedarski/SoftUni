namespace SIS.HTTP.Headers
{
	using Contracts;
	using System;
	using System.Collections.Generic;
	using Common;

	public class HttpHeaderCollection : IHttpHeaderCollection
	{
		private readonly IDictionary<string, HttpHeader> headers;

		public HttpHeaderCollection()
		{
			this.headers = new Dictionary<string, HttpHeader>();
		}
		public void Add(HttpHeader header)
		{

			Validator.ThrowIfNullOrEmpty(header.Key, nameof(header.Key));
			Validator.ThrowIfNullOrEmpty(header.Value, nameof(header.Value));

			this.headers[header.Key]= header;
		}

		public bool ContainsHeader(string key)
		{
			Validator.ThrowIfNullOrEmpty(key,nameof(key));
			return this.headers.ContainsKey(key);
		}

		public HttpHeader GetHeader(string key)
		{
			Validator.ThrowIfNullOrEmpty(key,nameof(key));

			if (this.ContainsHeader(key))
			{
				return this.headers[key];
			}
			return null;
		}

		public override string ToString()
		{
			return string.Join(Environment.NewLine, this.headers.Values);
		}
	}
}
