namespace SIS.HTTP.Cookies
{
	using System;
	using Common;
	using HTTP.Common;

	public class HttpCookie
	{
		public HttpCookie(string key, string value, int expires = CookiesConstants.HttpCookieDefaultExpirationDay)
		{
			this.Key = key;
			this.Value = value;
			this.Expires = DateTime.UtcNow.AddDays(expires);
		}
		public HttpCookie(string key, string value, bool isNew, int expires = CookiesConstants.HttpCookieDefaultExpirationDay )
			:this(key,value,expires)
		{
			this.IsNew = isNew;
		}
		public string Key { get; }
		public string Value { get; }

		public DateTime Expires { get; set; }

		public bool IsNew { get; }
		public bool HttpOnly { get; set; } = true;
		public void Delete()
		{
			this.Expires = DateTime.UtcNow.AddDays(-1);
		}
		public override string ToString()
		{
			var cookie = $"{this.Key}{GlobalConstants.HttpCookieKeyValueDelimiter}{this.Value}{GlobalConstants.HttpCookieStringDelimiter}{CookiesConstants.HttpCookieExpiresKey}{GlobalConstants.HttpCookieKeyValueDelimiter}{this.Expires:R}";
			if (this.HttpOnly)
			{
				cookie += $"{GlobalConstants.HttpCookieStringDelimiter}{CookiesConstants.HttpCookieHttpOnlyKey}";
			}
			return cookie;
			}
	}
}
