public abstract class Soldier:ISoldier
{
	private int id;
	private string firstName;
	private string secondName;

	public Soldier(int id, string firstName, string lastName)
	{
		this.Id = id;
		this.FirstName = firstName;
		this.SecondName = lastName;
	}

	public int Id
	{
		get { return this.id; }
		private set { this.id = value; }
	}
	public string FirstName
	{
		get { return this.firstName; }
		private set { this.firstName = value; }
	}
	public string SecondName
	{
		get { return this.secondName; }
		private set { this.secondName = value; }
	}

	public override string ToString()
	{
		return $"Name: {this.FirstName} {this.SecondName} Id: {this.Id}";
	}
}

