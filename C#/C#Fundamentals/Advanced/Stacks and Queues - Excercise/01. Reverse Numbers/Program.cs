using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(' ').ToArray().Reverse();
            Console.WriteLine(string.Join(" ",input));
            //var stack = new Stack<int>(input);

            //for (int i = 0; i < input.Length; i++)
            //{
            //    Console.Write("{0} ",stack.Pop());
            //}
           
        }
    }
}
