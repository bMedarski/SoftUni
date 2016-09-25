using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int input = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i<array.Length; i++)
            {
                for (int j=i+1; j<array.Length; j++)
                {
                    if (Math.Abs(array[i] - array[j]) == input)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
