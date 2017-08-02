using System;
using System.Linq;

class Program
{
	static void Main()
	{
		var list = new MyList<string>();
		while (true)
		{
			var input = Console.ReadLine().Split(' ').ToArray();
			if (input[0]=="END")
			{
				break;
			}	
			switch (input[0])
			{
				case "Add":
					list.Add(input[1]);
					break;
				case "Remove":
					Console.WriteLine(list.Remove(int.Parse(input[1])));
					break;
				case "Max":
					Console.WriteLine(list.Max());
					break;
				case "Min":
					Console.WriteLine(list.Min());
					break;
				case "Contains":
					Console.WriteLine(list.Contains(input[1]));
					break;
				case "Greater":
					Console.WriteLine(list.CountGreaterThan(input[1]));
					break;
				case "Print":
					list.Print();
					break;
				case "Swap":
					list.Swap(int.Parse(input[1]),int.Parse(input[2]));
					break;

			}
		}
	}
}

