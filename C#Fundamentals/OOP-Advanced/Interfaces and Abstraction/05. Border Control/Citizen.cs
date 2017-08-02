public class Citizen:IIdentifiable,IBirthdate,IBuyer
{
	private string name;
	private int age;
	private string id;
	private string birthdate;
	private int food;
	public Citizen(string name,int age,string id,string birthdate)
	{
		this.Name = name;
		this.Age = age;
		this.Id = id;
		this.Birthdate = birthdate;
		this.Food = 0;
	}
	public string Name { get { return this.name; } set { this.name = value; } }
	public int Age { get { return this.age; } set { this.age = value; } }
	public string Id { get { return this.id; } set { this.id = value; } }
	public string Birthdate { get { return this.birthdate; } set { this.birthdate = value; } }
	public int Food { get { return this.food; } set { this.food = value; } }
	public void BuyFood()
	{
		this.Food += 10;
	}
}

