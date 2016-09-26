using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long count = 1,
                element = array[0],
                max = 0,
                maxElement = array[0];

            for (long i = 1; i < array.Length; i++)
            {
                if (element+1 == array[i])
                {
                    //3 2 3 4 2 2 4
                    element = array[i];
                    count++;
                    if (max < count)
                    {
                        max = count;
                        maxElement = array[i];
                    }
                }
                else
                {
                    element = array[i];
                    count = 1;
                }
            }
            for (long i = 0; i < max; i++)
            {
                Console.Write("{0} ", maxElement+i-max+1);
            }
        }
    }
}
