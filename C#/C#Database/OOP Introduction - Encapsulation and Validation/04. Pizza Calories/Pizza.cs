using System;
using System.Collections.Generic;
public class Pizza
{
	private string name;
	private Dough dought;
	private List<Topping> toppings;
	private int toppingsCount;

	public Pizza(string name)
	{
		this.Name = name;
		this.toppings = new List<Topping>();

	}
	public int ToppingsCount
	{
		get { return this.toppingsCount; }
		private set
		{
			if (value < 0 || value > 10)
			{
				throw new ArgumentException("Number of toppings should be in range [0..10].");
			}
			this.toppingsCount = value;
		}
	}
	public string Name
	{
		get { return this.name; }
		set
		{
			//could be value<1
			if (string.Empty == value || value.Length > 15)
			{
				throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
			}
			this.name = value;
		}
	}

	public Dough Dough
	{
		get { return this.dought; }
		set { this.dought = value; }
	}

	public int ToppingsCounts()
	{
		return this.toppings.Count;
	}

	public void AddTopping(Topping topping)
	{
		//Potencial problem with ==10
		if (this.ToppingsCounts() == 10)
		{
			throw new ArgumentException("Number of toppings should be in range [0..10].");
		}
		this.toppings.Add(topping);
	}

	public double TotalCalories()
	{
		var calories = 0d;
		calories += this.Dough.Calories();
		foreach (var topping in toppings)
		{
			calories += topping.Calories();
		}
		return calories;
	}
}
