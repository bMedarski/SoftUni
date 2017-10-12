using System;
public class SoftUniAttribute : Attribute
{
	private string name;

	public SoftUniAttribute(string name)
	{
		this.Name = name;
	}

	public string Name
	{
		get => this.name;
		set => this.name = value;
	}
}

