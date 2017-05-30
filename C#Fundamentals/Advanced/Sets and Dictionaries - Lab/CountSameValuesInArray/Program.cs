using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            var numbers = new SortedDictionary<decimal, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (numbers.ContainsKey(input[i]))
                {
                    numbers[input[i]]++;
                }
                else
                {
                    numbers.Add(input[i],1);
                }
            }
            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
