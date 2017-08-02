using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	static void Main()
	{
		var people = new List<Person>();
		while (true)
		{
			var input = Console.ReadLine();
			if (input=="END")
			{
				break;
			}
			var args = input.Split(' ').ToList();
			people.Add(new Person(args[0],int.Parse(args[1]),args[2]));
		}
		var personIndex = int.Parse(Console.ReadLine());

		if (personIndex >= people.Count)
		{
			Console.WriteLine("No matches");
		}
		else
		{
			var person = people[personIndex];
			int countSame = 0;
			foreach (var person1 in people)
			{
				if (person1.Town==person.Town&&person1.Age==person.Age&&person1.Name==person.Name)
				{
					countSame++;
				}
			}
			Console.WriteLine($"{countSame} {people.Count-countSame} {people.Count}");
		}
	}
}

