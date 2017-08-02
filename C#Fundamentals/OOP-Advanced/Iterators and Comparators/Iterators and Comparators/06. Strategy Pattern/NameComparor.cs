
using System.Collections.Generic;

public class NameComparor : IComparer<Person>
{
	public int Compare(Person x, Person y)
	{
		if (x.Name.Length == y.Name.Length)
		{
			if (x.Name.ToLower()[0]==y.Name.ToLower()[0])
			{
				return 0;
			}
			return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
		}
		return x.Name.Length.CompareTo(y.Name.Length);
	}
}

