using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _07.Car_Salesman
{
    class Car
    {
        public string model;
        public Engine engine;
        public int weight;
        public string color;

        public Car(string model, Engine engine, int weight = 0, string color = "")
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }
        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.AppendLine($"{this.model}:");
            sb.AppendLine($"  {this.engine.ToString()}");
            if (this.weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.weight}");
            }
            if (this.color == "")
            {
                sb.Append($"  Color: n/a");
            }
            else
            {
                sb.Append($"  Color: {this.color}");
            }
            return sb.ToString();
        }
    }

    class Engine
    {
        public string model;
        public int power;
        public int displacement;
        public string efficiency;

        public Engine(string model, int power, int displacement = 0, string efficiency = "")
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.model}:");
            sb.AppendLine($"    Power: {this.power}");
            if (this.displacement==0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.displacement}");
            }
            if (this.efficiency=="")
            {
                sb.Append($"    Efficiency: n/a");
            }
            else
            {
                sb.Append($"    Efficiency: {this.efficiency}");
            }         
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            var engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = input[0];
                var power = int.Parse(input[1]);
                var displacement = 0;
                var efficiency = "";
                if (input.Length==4)
                {
                   displacement = int.Parse(input[2]);
                   efficiency = input[3]; 
                }
                if (input.Length==3)
                {
                    int n;
                    bool isNumeric = int.TryParse(input[2], out n);
                    if (isNumeric)
                    {
                        displacement = n;
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }
                
                engines.Add(new Engine(model,power,displacement,efficiency));
            }

            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = input[0];
                var engine = engines.Find(x => x.model == input[1]);
                var weight = 0;
                var color = "";
                if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                if (input.Length == 3)
                {
                    int n;
                    bool isNumeric = int.TryParse(input[2], out n);
                    if (isNumeric)
                    {
                        weight = n;
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                cars.Add(new Car(model,engine,weight,color));
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
