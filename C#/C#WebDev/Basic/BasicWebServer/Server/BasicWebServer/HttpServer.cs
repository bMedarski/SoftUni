using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BasicWebServer
{
    public class HttpServer:IHttpServer
    {
	    private bool isRunning;
	    private TcpListener tcpListener;
	    private const string Ip = "127.0.0.1";
	    private const int Port = 80;

		public HttpServer()
	    {
		    this.tcpListener = new TcpListener(IPAddress.Parse(Ip),Port);
	    }

	    public void Start()
	    {
			this.tcpListener.Start();
		    this.isRunning = true;
			
			Console.WriteLine("Server started");

			while (this.isRunning)
			{
				var client = this.tcpListener.AcceptTcpClient();
				var buffer = new byte[1024];
				var stream = client.GetStream();
				var readLength = stream.Read(buffer, 0, buffer.Length);
				var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
				Console.WriteLine(new string('=', 60));
				var requestTextLines = requestText.Split(Environment.NewLine);
				var firstLineArgs = requestTextLines[0].Split();
				var path = firstLineArgs[1];
				var responseText = "";
				var responseHeaders = "";
				Console.WriteLine(path);
				if (path == "/")
				{
					responseText = File.ReadAllText("index.html");
					responseHeaders = this.Home(responseText);
				}

				var responseBytes = Encoding.UTF8.GetBytes(
					responseHeaders + responseText);
				stream.Write(responseBytes);
			}
	    }

	    public void Stop()
	    {
		    this.isRunning = false;
	    }

	    public string Home(string responseText)
	    {
			var response = new StringBuilder();
		    response.AppendLine("HTTP/1.0 200 OK");
		    response.AppendLine("Content-Type: text/html");
		    response.AppendLine("Content-Length: " + responseText.Length);
		    response.AppendLine();
			return response.ToString();
	    }

	    public string FavIcon(string responseText)
	    {
		    var response = new StringBuilder();
		    response.AppendLine("HTTP/1.0 200 OK");
		    response.AppendLine("Content-Type: image/x-icon");
		    response.AppendLine("Content-Disposition: attachment; filename=favicon.ico");
		    response.AppendLine();
		    return response.ToString();
		}
    }
}
