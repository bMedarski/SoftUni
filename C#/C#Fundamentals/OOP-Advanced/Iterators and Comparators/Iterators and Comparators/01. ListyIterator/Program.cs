using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		var input = Console.ReadLine();
		List<string> collection = input.Split().ToList();
		collection.RemoveAt(0);

		var myList = new ListyIterator<string>(collection);

		while (input != "END")
		{
			switch (input)
			{

				case "HasNext":
					Console.WriteLine(myList.HasNext());
					break;
				case "Move":
					Console.WriteLine(myList.Move());
					break;
				case "Print":
					try
					{
						myList.Print();
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
					
					break;
				case "PrintAll":
					try
					{
						myList.PrintAll();
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}

					break;
			}
			input = Console.ReadLine();
		}

			
	}
}

