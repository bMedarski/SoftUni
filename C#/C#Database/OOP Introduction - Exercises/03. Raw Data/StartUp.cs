using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06.Raw_Data
{
	class Car
	{
		public string model;
		public Engine engine;
		public Cargo cargo;
		public Tire firstTire;
		public Tire secondTire;
		public Tire thirdTire;
		public Tire forthTire;

		public Car(string model, Engine engine, Cargo cargo, Tire firstTire, Tire secondTire, Tire thirdTire, Tire forthTire)
		{
			this.model = model;
			this.cargo = cargo;
			this.engine = engine;
			this.firstTire = firstTire;
			this.secondTire = secondTire;
			this.thirdTire = thirdTire;
			this.forthTire = forthTire;
		}
	}

	class Engine
	{
		public int speed;
		public int power;

		public Engine(int speed, int power)
		{
			this.speed = speed;
			this.power = power;
		}
	}

	class Tire
	{
		public double pressure;
		public int age;

		public Tire(double pressure, int age)
		{
			this.pressure = pressure;
			this.age = age;
		}
	}

	class Cargo
	{
		public int weight;
		public string type;

		public Cargo(int weight, string type)
		{
			this.weight = weight;
			this.type = type;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var count = int.Parse(Console.ReadLine());
			var cars = new List<Car>();
			for (int i = 0; i < count; i++)
			{
				var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
				var model = input[0];
				var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
				var cargo = new Cargo(int.Parse(input[3]), input[4]);
				var tire1 = new Tire(double.Parse(input[5], CultureInfo.InvariantCulture), int.Parse(input[6]));
				var tire2 = new Tire(double.Parse(input[7], CultureInfo.InvariantCulture), int.Parse(input[8]));
				var tire3 = new Tire(double.Parse(input[9], CultureInfo.InvariantCulture), int.Parse(input[10]));
				var tire4 = new Tire(double.Parse(input[11], CultureInfo.InvariantCulture), int.Parse(input[12]));

				var car = new Car(model, engine, cargo, tire1, tire2, tire3, tire4);
				cars.Add(car);
			}
			var command = Console.ReadLine();

			if (command == "fragile")
			{
				foreach (var car in cars.Where(x => x.cargo.type == command &&
				                                    (x.firstTire.pressure < 1 || x.secondTire.pressure < 1 ||
				                                     x.thirdTire.pressure < 1 || x.forthTire.pressure < 1)))
				{
					Console.WriteLine(car.model);
				}
			}
			else
			{
				foreach (var car in cars.Where(x => x.cargo.type == command && x.engine.power > 250))
				{
					Console.WriteLine(car.model);
				}
			}

		}
	}
}