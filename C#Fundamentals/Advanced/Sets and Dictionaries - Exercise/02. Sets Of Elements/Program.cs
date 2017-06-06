using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var n = input[0];
            var m = input[1];
            var set1 = new List<int>();

            for (int i = 0; i < n + m; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    set1.Add(number);
                }
                else
                {
                    if (set1.Contains(number))
                    {
                        Console.Write($"{number} ");
                    }
                }

            }
        }
    }
}