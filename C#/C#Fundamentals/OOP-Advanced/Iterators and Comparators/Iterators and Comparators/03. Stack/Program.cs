using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		var input = Console.ReadLine();
		List<string> collection = input.Split(new []{' ',','},StringSplitOptions.RemoveEmptyEntries).ToList();
		collection.RemoveAt(0);
		List<int> args = collection.Select(int.Parse).ToList();
		var myList = new Stack<int>(args);

		while (input != "END")
		{
			input = Console.ReadLine();
			var command = input.Split(' ').ToList();
			if (command[0] == "Push")
			{
				myList.Push(int.Parse(command[1]));
			}
			else if(command[0] == "Pop")
			{
				try
				{
					myList.Pop();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			
		}
		myList.Print();
		myList.Print();
	}
}

