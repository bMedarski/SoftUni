using System;
using System.Linq;

public class StartUp
{
	public static void Main(string[] args)
	{
		var numbers = Console.ReadLine().Split(' ').ToList();
		var sites = Console.ReadLine().Split(' ').ToList();
		var phone = new Smartphone(numbers, sites);
		Console.WriteLine(phone.Call());
		Console.WriteLine(phone.Browse());
	}
}