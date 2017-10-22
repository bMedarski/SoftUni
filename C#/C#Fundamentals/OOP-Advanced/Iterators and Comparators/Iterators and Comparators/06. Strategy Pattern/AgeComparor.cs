
using System.Collections.Generic;

public class AgeComparor : IComparer<Person>
{
	public int Compare(Person x, Person y)
	{
		return x.Age.CompareTo(y.Age);
	}
}

