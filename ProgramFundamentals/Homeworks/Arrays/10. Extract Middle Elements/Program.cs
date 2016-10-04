using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int length = array.Length;
            int deletedByTwo = length / 2;
            int modulByTwo = length % 2;

            if (length == 1)
            {
                Console.Write("{ ");
                Console.Write("{0}", array[0]);
                Console.Write(" }");
            } else if (length % 2 == 0)
            {
                Console.Write("{ ");
                Console.Write("{0},{1}", array[deletedByTwo-1], array[deletedByTwo]);
                Console.Write(" }");

                //Console.WriteLine($"{ {array[deletedByTwo - 1]},{array[deletedByTwo]} }");
            }
            else
            {
                Console.Write("{ ");
                Console.Write("{0},{1},{2}", array[deletedByTwo-1], array[deletedByTwo], array[deletedByTwo+1]);
                Console.Write(" }");
            }
        }
    }
}
