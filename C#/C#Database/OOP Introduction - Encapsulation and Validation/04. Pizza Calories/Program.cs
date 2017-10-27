
using System;
using System.Linq;

public class PizzaCalories
{
	public static void Main()
	{
		try
		{
			string[] pizzaInput = Console.ReadLine().Split(' ').ToArray();
			Pizza pizza = new Pizza(pizzaInput[1]);

			string[] doughInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
			Dough dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
			pizza.Dough = dough;
			while (true)
			{
				var input = Console.ReadLine();
				if (input == "END")
				{
					break;
				}

				string[] toppingInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
				Topping topping = new Topping(toppingInput[1], double.Parse(toppingInput[2]));
				pizza.AddTopping(topping);
			}
			Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}



	}
}

