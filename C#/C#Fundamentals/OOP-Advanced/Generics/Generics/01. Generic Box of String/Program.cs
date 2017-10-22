using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

class Program
{
	static void Main()
	{
		var count = int.Parse(Console.ReadLine());
		//	var box = new Box<int>();
		//	for (int i = 0; i < count; i++)
		//	{
		//		var val = int.Parse(Console.ReadLine());

		//		//var val = Console.ReadLine();

		//		box.AddToList(val);
		//	}
		//	var posstionsToSwap = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		//	box.Swap(posstionsToSwap[0], posstionsToSwap[1]);
		//	box.Print();
		//}
		var list = new List<double>();
		
		for (int i = 0; i < count; i++)
		{
			var val = double.Parse(Console.ReadLine());

			//var val = Console.ReadLine();

			list.Add(val);
		}

		var item = double.Parse(Console.ReadLine());
		var box = new Box<double>(item);
		var countItems = 0;
		foreach (var i in list)
		{
			if (box.CompareTo(i) < 0)
			{
				countItems++;
			}

		}
		Console.WriteLine(countItems);
	}
}

