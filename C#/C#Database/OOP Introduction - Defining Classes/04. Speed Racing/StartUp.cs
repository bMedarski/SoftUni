using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
	static void Main()
	{
		var cars = new List<Car>();

		var inputCount = int.Parse(Console.ReadLine());

		for (int i = 0; i < inputCount; i++)
		{
			var input = Console.ReadLine().Split().ToList();

			var car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
			cars.Add(car);
		}

		while (true)
		{

			var action = Console.ReadLine();
			if (action == "End")
			{
				break;
			}
			var actionSplit = action.Split().ToList();

			foreach (var car in cars)
			{
				if (car.Model == actionSplit[1])
				{
					car.Drive(int.Parse(actionSplit[2]));
				}
			}

		}

		foreach (var car in cars)
		{
			Console.WriteLine(car);
		}
	}
}
