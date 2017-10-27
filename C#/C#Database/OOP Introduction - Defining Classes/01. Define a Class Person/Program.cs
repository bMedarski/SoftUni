using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		//Type personType = typeof(Person);
		//PropertyInfo[] properties = personType.GetProperties
		//	(BindingFlags.Public | BindingFlags.Instance);
		//Console.WriteLine(properties.Length);


		//Type personType = typeof(Person);
		//ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
		//ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
		//ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
		//bool swapped = false;
		//if (nameAgeCtor == null)
		//{
		//	nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
		//	swapped = true;
		//}

		//string name = Console.ReadLine();
		//int age = int.Parse(Console.ReadLine());

		//Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
		//Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
		//Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

		//Console.WriteLine("{0} {1}", basePerson.Name, basePerson.Age);
		//Console.WriteLine("{0} {1}", personWithAge.Name, personWithAge.Age);
		//Console.WriteLine("{0} {1}", personWithAgeAndName.Name, personWithAgeAndName.Age);

		var persons = new List<Person>();

		var inputCount = int.Parse(Console.ReadLine());

		for (int i = 0; i < inputCount; i++)
		{
			var input = Console.ReadLine().Split().ToList();

			var person = new Person(input[0], int.Parse(input[1]));
			persons.Add(person);
		}

		foreach (var person in persons.OrderBy(x => x.Name))
		{
			if (person.Age > 30)
			{
				Console.WriteLine(person);
			}
		}
	}
}

