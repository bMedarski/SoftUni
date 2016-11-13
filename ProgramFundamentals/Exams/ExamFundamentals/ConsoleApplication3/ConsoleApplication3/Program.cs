using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SmallShop1
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine().ToLower();
            var town = Console.ReadLine().ToLower();
            var quantity = Double.Parse(Console.ReadLine());
            if (product == "coffee")
            {
                if (town == "sofia")
                {
                    Console.WriteLine(quantity * 0.50);
                }
                else if (town == "plovdiv")
                {
                    Console.WriteLine(quantity * 0.40);
                }
                else
                {
                    Console.WriteLine(quantity * 0.45);
                }
            }
            if (product == "water")
            {
                if (town == "sofia")
                {
                    Console.WriteLine(quantity * 0.80);
                }
                else if (town == "plovdiv")
                {
                    Console.WriteLine(quantity * 0.70);
                }
                else
                {
                    Console.WriteLine(quantity * 0.70);
                }
            }
            if (product == "beer")
            {
                if (town == "sofia")
                {
                    Console.WriteLine(quantity * 1.20);
                }
                else if (town == "plovdiv")
                {
                    Console.WriteLine(quantity * 1.15);
                }
                else
                {
                    Console.WriteLine(quantity * 1.10);
                }
            }
            if (product == "sweets")
            {
                if (town == "sofia")
                {
                    Console.WriteLine(quantity * 1.45);
                }
                else if (town == "plovdiv")
                {
                    Console.WriteLine(quantity * 1.30);
                }
                else
                {
                    Console.WriteLine(quantity * 1.35);
                }
            }
            if (product == "peanuts")
            {
                if (town == "sofia")
                {
                    Console.WriteLine(quantity * 1.60);
                }
                else if (town == "plovdiv")
                {
                    Console.WriteLine(quantity * 1.50);
                }
                else
                {
                    Console.WriteLine(quantity * 1.55);
                }
            }
        }
    }
}