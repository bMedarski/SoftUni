namespace SIS.WebServer
{
	using System;
	using System.Net.Sockets;
	using System.Text;
	using System.Threading.Tasks;
	using Api;
	using HTTP.Common;
	using HTTP.Cookies;
	using HTTP.Enums;
	using HTTP.Exceptions;
	using HTTP.Requests;
	using HTTP.Requests.Contracts;
	using HTTP.Responses.Contracts;
	using HTTP.Sessions;
	using Results;
	using Validator = HTTP.Common.Validator;

	public class ConnectionHandler
	{
	    private readonly Socket client;
	    private readonly IHttpHandler handler;
	
	    public ConnectionHandler(Socket client, IHttpHandler handler)
	    {
		    Validator.ThrowIfNull(client, nameof(client));
		    Validator.ThrowIfNull(handler, nameof(handler));
		    this.client = client;
		    this.handler = handler;
	    }

	    private async Task<IHttpRequest> ReadRequest()
	    {
			var result = new StringBuilder();
			var data = new ArraySegment<byte>(new byte[1024]);

		    while (true)
		    {
			    int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

			    if (numberOfBytesRead == 0)
			    {
					break;
			    }

			    var byteAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
			    result.Append(byteAsString);

			    if (numberOfBytesRead < 1023)
			    {
					break;
			    }
		    }

		    if (result.Length == 0)
		    {
			    return null;
		    }

			return new HttpRequest(result.ToString());
	    }

		private async Task PrepareResponse(IHttpResponse response)
	    {
		    byte[] byteSegments = response.GetBytes();

		    await this.client.SendAsync(byteSegments, SocketFlags.None);
	    }

	    public async Task ProcessRequestAsync()
	    {
			//try
			//{
				var httpRequest = await this.ReadRequest();

			    if (httpRequest != null)
			    {
				    var sessionId = this.SetRequestSession(httpRequest);
				    var httpResponse = this.handler.Handle(httpRequest);
					this.SetResponseSession(httpResponse, sessionId);
				    await this.PrepareResponse(httpResponse);
			    }
		//}
			//catch (BadRequestException e)
			//{
			//	await this.PrepareResponse(new TextResult(e.StackTrace, HttpResponseStatusCode.BadRequest));
			//}
			//catch (Exception e)
			//{
			//	await this.PrepareResponse(new TextResult(e.StackTrace, HttpResponseStatusCode.InternalServerError));
			//}
			this.client.Shutdown(SocketShutdown.Both);
	    }

		private string SetRequestSession(IHttpRequest httpRequest)
		{
			string sessionId = null;

			if (httpRequest.Cookies.ContainsCookie(GlobalConstants.SessionCookieKey))
			{
				var cookie = httpRequest.Cookies.GetCookie(GlobalConstants.SessionCookieKey);
				sessionId = cookie.Value;
				httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
			}
			else
			{
				sessionId = Guid.NewGuid().ToString();
				httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
			}

			return sessionId;
		}

		private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
		{
			if (sessionId != null)
			{
				httpResponse.AddCookie(new HttpCookie(GlobalConstants.SessionCookieKey,sessionId));
			}
		}
	}
}
