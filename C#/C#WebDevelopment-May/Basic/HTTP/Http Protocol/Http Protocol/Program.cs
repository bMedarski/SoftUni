using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Http_Protocol
{
    class Program
    {
        static void Main()
        {

			//UrlDecode();
			//ValidateUrl();
			//RequestParser();

        }

	    private static void RequestParser()
	    {
			var post = new List<string>();
		    var get = new List<string>();
			var response = new Dictionary<int,string>();
			response.Add(404,"Not Found");
			response.Add(200,"OK");

		    while (true)
		    {
			    var input = Console.ReadLine();
			    if (input == "END")
			    {
				    break;
			    }

			    var request = input.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
			    if (request[1].ToLower() == "post")
			    {
				    post.Add(request[0]);
			    }else if (request[1].ToLower() == "get")
			    {
				    get.Add(request[0]);
			    }
			    else
			    {
				    throw new ArgumentException();
			    }
				
		    }

		    var HttpRequest = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);

		    if (HttpRequest[0].ToUpper() == "GET")
		    {
			    if (get.Contains(HttpRequest[1].TrimStart('/')))
			    {
					PrintResponse(response[200], 200);
				}
			    else
			    {
					PrintResponse(response[404], 404);
				}
		    }else if (HttpRequest[0].ToUpper() == "POST")
		    {
				if (post.Contains(HttpRequest[1].TrimStart('/')))
				{
					PrintResponse(response[200], 200);
				}
				else
				{
					PrintResponse(response[404], 404);
				}
			}
		    else
		    {
			    throw new ArgumentException();
		    }
	    }
	    private static void UrlDecode()
	    {
		    var urlToDecode = Console.ReadLine();
		    var decodedUrl = WebUtility.UrlDecode(urlToDecode);
			Console.WriteLine(decodedUrl);
	    }
	    private static void ValidateUrl()
	    {
			var urlToValidate = Console.ReadLine();

		    try
		    {
				var url = new Uri(urlToValidate);
			    if (!url.IsDefaultPort)
			    {
					Console.WriteLine("Invalid URL");
					return;
				}

				if (url.Scheme == ""||url.Host=="")
			    {
					throw new Exception();
				}
				Console.WriteLine($"Protocol:{url.Scheme}");
				Console.WriteLine($"Host:{url.Host}");
			    Console.WriteLine($"Port:{url.Port}");
			    Console.WriteLine($"Path:{url.AbsolutePath}");
			    if (url.Query != "")
			    {
					Console.WriteLine($"Query:{url.Query.TrimStart('?')}");
				}
			    if (url.Fragment != "")
			    {
				    Console.WriteLine($"Fragment:{url.Fragment.TrimStart('#')}");
			    }
			}
		    catch (Exception )
		    {
			    Console.WriteLine("Invalid URL");
		    }
		}

		private static void PrintResponse(string message,int code)
	    {
		    var sb = new StringBuilder();
		    sb.AppendLine($"HTTP/1.1 {code} {message}");
		    sb.AppendLine($"Content-Length: {message.Length}");
		    sb.AppendLine("Content-Type: text/plain");
		    sb.AppendLine();
		    sb.AppendLine($"{message}");

			Console.WriteLine(sb.ToString());


	    }
	}
}
