namespace SIS.Webserver
{
	using System;
	using System.Net.Sockets;
	using System.Text;
	using System.Threading.Tasks;
	using HTTP.Common;
	using HTTP.Cookies;
	using HTTP.Enums;
	using HTTP.Exceptions;
	using HTTP.Requests;
	using HTTP.Requests.Contracts;
	using HTTP.Responses;
	using HTTP.Responses.Contracts;
	using HTTP.Sessions;
	using Results;
	using Routing;

	public class ConnectionHandler
    {
	    private readonly Socket client;
	    private readonly ServerRoutingTable serverRoutingTable;
	    public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
	    {
		    Validator.ThrowIfNull(client, nameof(client));
		    Validator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));
		    this.client = client;
		    this.serverRoutingTable = serverRoutingTable;
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

	    private IHttpResponse HandleRequest(IHttpRequest request)
	    {
		    if (!this.serverRoutingTable.Routes.ContainsKey(request.RequestMethod) ||
		        !this.serverRoutingTable.Routes[request.RequestMethod].ContainsKey(request.Path))
		    {
				return new HttpResponce(HttpResponseStatusCode.NotFound);
		    }

		    return this.serverRoutingTable.Routes[request.RequestMethod][request.Path].Invoke(request);
	    }

	    private async Task PrepareResponse(IHttpResponse response)
	    {
		    byte[] byteSegments = response.GetBytes();

		    await this.client.SendAsync(byteSegments, SocketFlags.None);
	    }

	    public async Task ProcessRequestAsync()
	    {
		    try
		    {
			    var httpRequest = await this.ReadRequest();

			    if (httpRequest != null)
			    {
				    string sessionId = this.SetRequestSession(httpRequest);

				    var httpResponse = this.HandleRequest(httpRequest);

				    this.SetResponseSession(httpResponse, sessionId);

				    await this.PrepareResponse(httpResponse);
			    }
		    }
		    catch (BadRequestException e)
		    {
			    await this.PrepareResponse(new TextResult(e.Message, HttpResponseStatusCode.BadRequest));
		    }
		    catch (Exception e)
		    {
			    await this.PrepareResponse(new TextResult(e.Message, HttpResponseStatusCode.InternalServerError));
		    }


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
				httpResponse.AddCookie(new HttpCookie(GlobalConstants.SessionCookieKey,$"{sessionId}"));
			}
		}
	}
}
