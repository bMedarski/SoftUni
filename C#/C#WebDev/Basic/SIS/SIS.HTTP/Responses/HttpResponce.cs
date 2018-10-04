namespace SIS.HTTP.Responses
{
	using System.Linq;
	using System.Net.Http.Headers;
	using System.Text;
	using Common;
	using Contracts;
	using Cookies;
	using Cookies.Contracts;
	using Enums;
	using Extensions;
	using Headers;
	using Headers.Contracts;

	public class HttpResponce : IHttpResponse
	{
		public HttpResponce()
		{
			
		}
		public HttpResponce(HttpResponseStatusCode statusCode)
		{
			this.StatusCode = statusCode;
			this.Headers = new HttpHeaderCollection();
			this.Cookies = new HttpCookiesCollection();
			this.Content = new byte[0];
		}

		public HttpResponseStatusCode StatusCode { get; set; }

		public IHttpHeaderCollection Headers { get; private set; }
		public IHttpCookiesCollection Cookies { get; private set; }
		public byte[] Content { get; set; }

		public void AddHeader(HttpHeader header)
		{
			Validator.ThrowIfNull(header, nameof(header));
			this.Headers.Add(header);
		}

		public void AddCookie(HttpCookie cookie)
		{
			Validator.ThrowIfNull(cookie, nameof(cookie));
			this.Cookies.Add(cookie);
		}

		public byte[] GetBytes()
		{
			return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
		}

		public override string ToString()
		{
			var result = new StringBuilder();

			result.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}");
			result.AppendLine(this.Headers.ToString());
			result.AppendLine();

			return result.ToString();

		}
	}
}
