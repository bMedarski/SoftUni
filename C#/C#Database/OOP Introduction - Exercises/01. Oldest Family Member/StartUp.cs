using System;
using System.Linq;
using System.Reflection;

class StartUp
{
	static void Main()
	{
		MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
		MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
		if (oldestMemberMethod == null || addMemberMethod == null)
		{
			throw new Exception();
		}

		var peopleCount = int.Parse(Console.ReadLine());
		var family = new Family();

		for (int i = 0; i < peopleCount; i++)
		{
			var input = Console.ReadLine().Split(' ').ToArray();

			var person = new Person(input[0],int.Parse(input[1]));
			family.AddMember(person);
		}

		Console.WriteLine(family.GetOldestMember());
	}
}

