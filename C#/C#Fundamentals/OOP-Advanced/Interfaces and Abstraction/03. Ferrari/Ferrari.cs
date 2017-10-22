using System;

public class Ferrari:ICar
{
	private string model;
	private string name;

	public Ferrari(string name)
	{
		this.name = name;
		this.model = "488-Spider";
	}


	public string Brakes()
	{
		return "Brakes!";
	}

	public string Gas()
	{
		return "Zadu6avam sA!";
	}

	public override string ToString()
	{
		return $"{this.model}/{this.Brakes()}/{this.Gas()}/{this.name}";
	}
}

