using System;

public class Person: IComparable<Person>
{
	private string name;
	private int age;
	private string town;

	public Person(string name, int age, string town)
	{
		this.Name = name;
		this.Age = age;
		this.Town = town;
	}

	public string Name
	{
		get => this.name;
		private set => this.name = value;
	}

	public int Age
	{
		get => this.age;
		private set => this.age = value;
	}

	public string Town
	{
		get => this.town;
		private set => this.town = value;
	}

	public int CompareTo(Person obj)
	{
		if (this.Name.CompareTo(obj.Name)==0)
		{
			if (this.Age.CompareTo(obj.Age) == 0)
			{
				if (this.Town.CompareTo(obj.Town) == 0)
				{
					return 0;
				}
				return this.Town.CompareTo(obj.Town);
			}
			return this.Age.CompareTo(obj.Age);
		}
		return this.Name.CompareTo(obj.Name);
	}
}

