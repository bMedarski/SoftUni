public abstract class Monument
{
	private string name;

	public Monument(string name)
	{
		this.Name = name;
	}

	public string Name
	{
		get => name;
		private set => name = value;
	}

	public abstract int Affinity();

}

