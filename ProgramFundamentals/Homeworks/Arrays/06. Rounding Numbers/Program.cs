using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i<input.Length; i++)
            {             
                    double rounded = Math.Round(input[i], 0, MidpointRounding.AwayFromZero);
                    Console.WriteLine("{0} => {1}", input[i], rounded);              
            }

        }
    }
}
