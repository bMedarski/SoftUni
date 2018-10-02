namespace SIS.Webserver
{
	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading.Tasks;
	using Routing;

	public class Server
	{
		private const string LocalIpAddress = "127.0.0.1";
		private readonly int port;
		private readonly TcpListener listener;
		private readonly ServerRoutingTable serverRoutingTable;
		private bool isRunning;

		public Server(int port, ServerRoutingTable serverRoutingTable)
		{
			this.serverRoutingTable = serverRoutingTable;
			this.port = port;
			this.listener = new TcpListener(IPAddress.Parse(LocalIpAddress), port);
		}

		public void Run()
		{
			this.listener.Start();
			this.isRunning = true;

			Console.WriteLine($"Server is started at http//{LocalIpAddress}:{this.port}");

			var task = Task.Run(this.ListneLoop);
			task.Wait();
		}

		public async Task ListneLoop()
		{
			while (this.isRunning)
			{
				var client = await this.listener.AcceptSocketAsync();
				var connectionHandler = new ConnectionHandler(client,this.serverRoutingTable);
				var responseTask = connectionHandler.ProcessRequesteAsync();
				responseTask.Wait();
			}
		}
	}
}
