using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var remainderZero = new List<int>();
            var remainderOne = new List<int>();
            var remainderTwo = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 3 == 0)
                {
                    remainderZero.Add(input[i]);
                }
                else if(Math.Abs(input[i] % 3) == 1)
                {
                    remainderOne.Add(input[i]);
                }
                else if (Math.Abs(input[i] % 3) == 2)
                {
                    remainderTwo.Add(input[i]);
                }
            }
            Console.WriteLine(string.Join(" ",remainderZero));
            Console.WriteLine(string.Join(" ", remainderOne));
            Console.WriteLine(string.Join(" ", remainderTwo));
        }
    }
}
