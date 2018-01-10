using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine().ToLower();
            var town = Console.ReadLine().ToLower();
            var quantity = double.Parse(Console.ReadLine());
            if (town == "sofia")
            {
                if (product == "coffee")
                    Console.WriteLine(0.50 * quantity);
                if (product == "water")
                    Console.WriteLine(0.80 * quantity);
                if (product == "beer")
                    Console.WriteLine(1.20 * quantity);
                if (product == "sweets")
                    Console.WriteLine(1.45 * quantity);
                if (product == "peanuts")
                    Console.WriteLine(1.60 * quantity);
            }
            else if(town == "varna")
            {
                if (product == "coffee")
                    Console.WriteLine(0.45 * quantity);
                if (product == "water")
                    Console.WriteLine(0.70 * quantity);
                if (product == "beer")
                    Console.WriteLine(1.10 * quantity);
                if (product == "sweets")
                    Console.WriteLine(1.35 * quantity);
                if (product == "peanuts")
                    Console.WriteLine(1.55 * quantity);
            }
            else if(town == "plovdiv")
            {
                if (product == "coffee")
                    Console.WriteLine(0.40 * quantity);
                if (product == "water")
                    Console.WriteLine(0.70 * quantity);
                if (product == "beer")
                    Console.WriteLine(1.15 * quantity);
                if (product == "sweets")
                    Console.WriteLine(1.30 * quantity);
                if (product == "peanuts")
                    Console.WriteLine(1.50 * quantity);
            }
        }
    }
}