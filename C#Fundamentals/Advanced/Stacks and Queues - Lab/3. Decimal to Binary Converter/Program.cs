using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var toAdd = 0;

            if (input==0)
            {
                Console.WriteLine(0);
            }
            while (input>0)
            {
                toAdd = input % 2;
                stack.Push(toAdd);
                input /= 2;
            }

            while (stack.Count!=0)
            {
                Console.Write(stack.Peek());
                stack.Pop();
            }    
            Console.WriteLine();           
        }
    }
}
