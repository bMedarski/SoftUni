namespace SIS.Webserver.Results
{
	using HTTP.Enums;
	using HTTP.Headers;
	using HTTP.Responses;
	public class InlineResourceResult:HttpResponce
	{
		public InlineResourceResult(byte[] content, HttpResponseStatusCode responseStatusCode)
		:base(responseStatusCode)
		{
			this.Headers.Add(new HttpHeader(HttpHeader.ContentLength, content.Length.ToString()));
			this.Headers.Add(new HttpHeader(HttpHeader.ContentDisposition, "inline"));
			this.Content = content;
		}
	}
}
