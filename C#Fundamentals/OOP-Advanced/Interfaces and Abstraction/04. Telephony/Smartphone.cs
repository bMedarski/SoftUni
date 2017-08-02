using System;
using System.Text.RegularExpressions;

public class Smartphone:ICall,IBrowse
{
	public void Call(string number)
	{
		string pattern = @"\d+";
		Regex rgx = new Regex(pattern);
		if (rgx.IsMatch(number))
		{
			Console.WriteLine($"Calling... {number}");
		}
		else
		{
			Console.WriteLine($"Invalid number!");
		}
	}

	public void Browse(string site)
	{
		string pattern = @"\d+";
		Regex rgx = new Regex(pattern);
		if (!rgx.IsMatch(site))
		{
			Console.WriteLine($"Browsing: {site}!");
		}
		else
		{
			Console.WriteLine($"Invalid URL!");
		}
	}
}

