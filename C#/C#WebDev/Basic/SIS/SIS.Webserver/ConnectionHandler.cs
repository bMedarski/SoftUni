namespace SIS.Webserver
{
	using System;
	using System.Net.Sockets;
	using System.Text;
	using System.Threading.Tasks;
	using HTTP.Enums;
	using HTTP.Requests;
	using HTTP.Requests.Contracts;
	using HTTP.Responses;
	using HTTP.Responses.Contracts;
	using Routing;

	public class ConnectionHandler
    {
	    private readonly Socket client;
	    private readonly ServerRoutingTable serverRoutingTable;
	    public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
	    {
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

	    public async Task ProcessRequesteAsync()
	    {
		    var httpRequest = await this.ReadRequest();

		    if (httpRequest != null)
		    {
			    var httpResponce = this.HandleRequest(httpRequest);

			    await this.PrepareResponse(httpResponce);
		    }

			this.client.Shutdown(SocketShutdown.Both);
	    }
    }
}
