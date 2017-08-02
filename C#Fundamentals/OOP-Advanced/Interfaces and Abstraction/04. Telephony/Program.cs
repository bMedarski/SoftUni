using System;
using System.Linq;

public class Program
{
	static void Main()
	{
		var numbers = Console.ReadLine().Split(' ').ToArray();
		var sites = Console.ReadLine().Split(' ').ToArray();

		var phone = new Smartphone();
		foreach (var number in numbers)
		{
			phone.Call(number);
		}
		foreach (var site in sites)
		{
			phone.Browse(site);
		}
	}
}
