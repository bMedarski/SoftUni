public class Person
{
	private string name;
	private int age;

	public Person(string name, int age)
	{
		this.name = name;
		this.age = age;
	}

	public string Name
	{
		get { return this.name; }
		protected set { this.name = value; }
	}

	public int Age
	{
		get { return this.age; }
		protected set { this.age = value; }
	}

	public override string ToString()
	{
		return $"{this.Name} {this.Age}";
	}
}


