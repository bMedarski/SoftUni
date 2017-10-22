using System;
using System.Linq;

class Program
{
	static void Main()
	{

		var input = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
			.ToList();

		var Lake = new Lake(input);
		Console.WriteLine(string.Join(", ",Lake));
	}
}

