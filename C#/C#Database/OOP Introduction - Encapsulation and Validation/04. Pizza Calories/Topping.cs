using System;

public class Topping
{
	private string type;
	private double weight;

	public Topping(string type, double weight)
	{
		this.Type = type;
		this.Weight = weight;
	}
	private string Type
	{
		get { return this.type; }
		set
		{
			if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
			{
				throw new ArgumentException($"Cannot place {value} on top of your pizza.");
			}
			this.type = value;
		}
	}

	private double Weight
	{
		get { return this.weight; }
		set
		{
			if (value < 1 || value > 50)
			{
				throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
			}
			this.weight = value;
		}
	}
	public double Calories()
	{
		double calories = 2;
		if (Type.ToLower() == "meat")
		{
			calories *= Modifiers.MEAT;
		}
		else if (Type.ToLower() == "veggies")
		{
			calories *= Modifiers.VEGGIES;
		}
		else if (Type.ToLower() == "cheese")
		{
			calories *= Modifiers.CHEESE;
		}
		else
		{
			calories *= Modifiers.SAUCE;
		}
		return calories * this.Weight;
	}
}
