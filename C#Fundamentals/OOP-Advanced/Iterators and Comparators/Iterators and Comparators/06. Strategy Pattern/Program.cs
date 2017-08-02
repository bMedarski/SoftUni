using System;
using System.Collections.Generic;

public class Program
{
	static void Main()
	{
		var nameComparedPeople = new SortedSet<Person>(new NameComparor());
		var ageComparedPeople = new SortedSet<Person>(new AgeComparor());

		int n = int.Parse(Console.ReadLine());

		for (int i = 0; i < n; i++)
		{
			var tokens = Console.ReadLine().Split();

			var newPerson = new Person(tokens[0], int.Parse(tokens[1]));

			nameComparedPeople.Add(newPerson);
			ageComparedPeople.Add(newPerson);
		}

		foreach (var person in nameComparedPeople)
		{
			Console.WriteLine(person);
		}

		foreach (var person in ageComparedPeople)
		{
			Console.WriteLine(person);
		}

	}
}

