using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = 1,
                element = array[0],
                max=0,
                maxElement= array[0];

            for (int i = 1; i<array.Length; i++)
            {
                if (element == array[i])
                {
                    count++;
                    if (max<count)
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
            for (int i = 0; i<max; i++)
            {
                Console.Write("{0} ", maxElement);
            }
            

        }
    }
}
