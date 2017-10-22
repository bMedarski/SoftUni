using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            var reverse = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reverse.Pop());
            }

            Console.WriteLine();
        }
    }
}
