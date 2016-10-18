using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, double> menu = new Dictionary<string, double>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                menu[input[0]] = double.Parse(input[1]);
            }



            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }
        }
    }
}
