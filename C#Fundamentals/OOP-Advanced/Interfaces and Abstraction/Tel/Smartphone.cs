using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
public class Smartphone : ICallable, IBrowsable
{
	public Smartphone(List<string> numbers, List<string> webSites)
	{
		this.Numbers = numbers;
		this.WebSites = webSites;
	}

	public List<string> Numbers { get; set; }

	public string Call()
	{
		StringBuilder sb = new StringBuilder();
		foreach (var number in Numbers)
		{
			if (!IsDigitsOnly(number))
			{
				sb.AppendLine("Invalid number!");
			}
			else
			{
				sb.AppendLine($"Calling... {number}");
			}
		}
		return sb.ToString().Trim();
	}

	public List<string> WebSites { get; set; }

	public string Browse()
	{
		StringBuilder sb = new StringBuilder();
		foreach (var site in WebSites)
		{
			if (Regex.IsMatch(site, @"\d+"))
			{
				sb.AppendLine("Invalid URL!");
			}
			else
			{
				sb.AppendLine($"Browsing: {site}!");
			}
		}
		return sb.ToString().Trim();
	}

	private bool IsDigitsOnly(string str)
	{
		foreach (char c in str)
		{
			if (c < '0' || c > '9')
				return false;
		}

		return true;
	}

	private bool HasAnyDigits(string str)
	{
		if (str.Any(c => c >= '0' || c <= '9'))
		{
			return false;
		}
		return true;
	}
}
