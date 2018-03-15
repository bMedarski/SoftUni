using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		var list = Console.ReadLine().Split().Select(int.Parse).ToList();
		var numberCounts = new Dictionary<int, int>();

		for (int i = 0; i < list.Count; i++)
		{
			var number = list[i];
			if (numberCounts.ContainsKey(number))
			{
				numberCounts[number]++;
			}
			else
			{
				numberCounts.Add(number, 1);
			}
		}
		foreach (var number in numberCounts.OrderBy(a => a.Key))
		{
			Console.WriteLine($"{number.Key} -> {number.Value} times");
		}
	}
}

