using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HTTP_Protocol
{
	public static class Program
	{
		static void Main()
		{

			//var url = Console.ReadLine();
			//Console.WriteLine(UrlDecoder(url));
			//ValidateUrl(url);

			RequestParser();

		}


		public static string UrlDecoder(string url)
		{
			var decodedUrl = WebUtility.UrlDecode(url);
			return decodedUrl;
		}

		public static void ValidateUrl(string url)
		{
			var decodedUrl = UrlDecoder(url);
			var urlParsed = new Uri(decodedUrl);
			var scheme = urlParsed.Scheme;
			var host = urlParsed.Host;
			var port = urlParsed.Port;
			var fragment = urlParsed.Fragment;
			var path = urlParsed.AbsolutePath;
			var query = urlParsed.Query;
			if (!urlParsed.IsDefaultPort)
			{
				Console.WriteLine("Invalid URL");
				return;
			}
			if (scheme == "" || host == "")
			{
				Console.WriteLine("Invalid URL");
				return;
			}

			var sb = new StringBuilder();
			sb.AppendLine($"Protocol:{scheme}");
			sb.AppendLine($"Host:{host}");
			sb.AppendLine($"Port:{port}");
			sb.AppendLine($"Path:{path}");
			if (query != "")
			{
				sb.AppendLine($"Query:{query.Substring(1)}");
			}

			if (fragment!="")
			{
				sb.AppendLine($"Fragment:{fragment.Substring(1)}");
			}
			sb.ToString();
			Console.WriteLine(sb);

		}

		public static void RequestParser()
		{
			var getList = new List<string>();
			var postList = new List<string>();

			while (true)
			{
				var input = Console.ReadLine();
				if (input == "END")
				{
					break;
				}

				var inputArgs = input.Split("/");
				if (inputArgs[2] == "get")
				{
					getList.Add(inputArgs[1]);
				}
				else if (inputArgs[2] == "post")
				{
					postList.Add(inputArgs[1]);
				}
			}

			var request = Console.ReadLine().Split();
			var method = request[0];
			var protocol = request[2];
			var path = request[1].Substring(1);

			var okResponse = new StringBuilder();
			okResponse.AppendLine($"{protocol} 200 OK");
			okResponse.AppendLine($"Content-Length: 2");
			okResponse.AppendLine($"Content-Type: text/plain");
			okResponse.AppendLine();
			okResponse.AppendLine("Ok");
			var oKResponseText = okResponse.ToString();

			var notFoundResponse = new StringBuilder();
			notFoundResponse.AppendLine($"{protocol} 404 Not Found");
			notFoundResponse.AppendLine($"Content-Length: 9");
			notFoundResponse.AppendLine($"Content-Type: text/plain");
			notFoundResponse.AppendLine();
			notFoundResponse.AppendLine("Not Found");
			var notFoundResponseText = notFoundResponse.ToString();

			Console.WriteLine(notFoundResponseText);
			if (method == "POST")
			{
				if (postList.Contains(path))
				{
					Console.WriteLine(oKResponseText);
				}
				else
				{
					Console.WriteLine(notFoundResponseText);
				}
			}
			else
			{
				if (postList.Contains(path))
				{
					Console.WriteLine(oKResponseText);
				}
				else
				{
					Console.WriteLine(notFoundResponseText);
				}
			}
			
		}
	}

}
