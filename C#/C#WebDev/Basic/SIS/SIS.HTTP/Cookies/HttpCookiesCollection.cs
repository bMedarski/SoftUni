﻿using System.Collections;

namespace SIS.HTTP.Cookies
{
	using System.Collections.Generic;
	using Contracts;
	using HTTP.Common;

	public class HttpCookiesCollection : IHttpCookiesCollection
	{
		private readonly IDictionary<string, HttpCookie> cookies;

		public HttpCookiesCollection()
		{
			this.cookies = new Dictionary<string, HttpCookie>();
		}

		public void Add(HttpCookie cookie)
		{
			Validator.ThrowIfNull(cookie, nameof(cookie));
			this.cookies.Add(cookie.Key, cookie);
		}

		public bool ContainsCookie(string key)
		{
			Validator.ThrowIfNull(key, nameof(key));
			return this.cookies.ContainsKey(key);
		}

		public HttpCookie GetCookie(string key)
		{
			Validator.ThrowIfNull(key, nameof(key));
			if (!this.cookies.ContainsKey(key))
			{
				return null;
			}
			return this.cookies[key];
		}

		public bool HasCookies()
		{
			return this.cookies.Count > 0;
		}

		public IEnumerator<HttpCookie> GetEnumerator()
		{
			foreach (var cookie in this.cookies)
			{
				yield return cookie.Value;
			}
		}

		public override string ToString()
		{
			return string.Join(GlobalConstants.HttpCookieStringDelimiter, this.cookies.Values);	///TODO: ReWrite
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}