using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _05.Speed_Racing
{
    class Car
    {
        public string model;
        public double fuel;
        public double costPerKm;
        public double distance=0;

        public Car(string model, double fuel, double costPerKm)
        {
            this.model = model;
            this.fuel = fuel;
            this.costPerKm = costPerKm;
        }

        public bool isEnoughFuel(double distance)
        {
            if (distance * costPerKm <= fuel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var countCars = int.Parse(Console.ReadLine());
            var Cars = new List<Car>();

            for (int i = 0; i < countCars; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var model = input[0];
                var fuel = double.Parse(input[1], CultureInfo.InvariantCulture);
                var costPerKm = double.Parse(input[2], CultureInfo.InvariantCulture);
                Cars.Add(new Car(model,fuel,costPerKm));
            }

            while (true)
            {
                var action = Console.ReadLine();
                if (action == "End")
                {
                    break;
                }
                var actionSpltit = action.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var carToMove = actionSpltit[1];
                double distance = double.Parse(actionSpltit[2],CultureInfo.InvariantCulture);
                var currentCar = Cars.Where(x => x.model == carToMove).First();
                if (currentCar.isEnoughFuel(distance))
                {
                    currentCar.fuel -= currentCar.costPerKm * distance;
                    currentCar.distance += distance;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
            foreach (var car in Cars)
            {
                Console.WriteLine($"{car.model} {car.fuel:F2} {car.distance}");
            }
           
        }
    }
}
