public class Pet:IBirthdate
{
	private string name;
	private string birthdate;

	public Pet(string name, string birthdate)
	{
		this.Name = name;
		this.Birthdate = birthdate;
	}
	public string Name { get { return this.name; } set { this.name = value; } }
	public string Birthdate { get { return this.birthdate; } set { this.birthdate = value; } }
}
