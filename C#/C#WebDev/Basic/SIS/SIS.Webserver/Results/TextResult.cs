namespace SIS.WebServer.Results
{
	using System.Text;
	using HTTP.Enums;
	using HTTP.Headers;
	using HTTP.Responses;

	public class TextResult : HttpResponce
	{
		private const string ContentTypeHeaderKey = "Content-type";
		private const string ContentTypeHeaderValue = "Text/plain; charset=utf-8";
		public TextResult(string content,HttpResponseStatusCode responseStatusCode)
			:base(responseStatusCode)
		{
			this.Headers.Add(new HttpHeader(ContentTypeHeaderKey,ContentTypeHeaderValue));
			this.Content = Encoding.UTF8.GetBytes(content);
		}
	}
}
