using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = numbers.Length / 4;

            int[] left = numbers.Take(k).Reverse().ToArray();
            int[] right = numbers.Reverse().Take(k).ToArray();
            int[] middle = numbers.Skip(k).Take(k * 2).ToArray();

            for (int i=0; i<k; i++)
            {
                middle[i] += left[i];
                middle[i + k] += right[i];
            }
            Console.WriteLine(string.Join(" ",middle));
        }
    }
}
