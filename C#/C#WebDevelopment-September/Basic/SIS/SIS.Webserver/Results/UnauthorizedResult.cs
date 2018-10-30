namespace SIS.WebServer.Results
{
	using System.Text;
	using HTTP.Enums;
	using HTTP.Headers;
	using HTTP.Responses;

	public class UnauthorizedResult : HttpResponce
	{
		private const string DefaultErrorHeading = "<h1>You have no premission to access this functionality</h1>";
		private const string ContentTypeHeaderKey = "Content-type";
		private const string ContentTypeHeaderValue = "Text/html; charset=utf-8";
		public UnauthorizedResult()
			:base(HttpResponseStatusCode.Unauthorized)
		{
			this.Headers.Add(new HttpHeader(ContentTypeHeaderKey,ContentTypeHeaderValue));
			this.Content = Encoding.UTF8.GetBytes(DefaultErrorHeading);
		}
	}
}