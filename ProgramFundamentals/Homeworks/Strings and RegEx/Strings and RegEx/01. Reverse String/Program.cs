using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            for (int i = input.Length-1; i >= 0; i--)
            {
                output.Append(input[i]);
            }
            Console.WriteLine(output.ToString());
        }
    }
}
