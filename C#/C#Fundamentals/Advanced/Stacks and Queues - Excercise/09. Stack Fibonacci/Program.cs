using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            ulong num = ulong.Parse(Console.ReadLine());

            var stack = new Stack<ulong>();
            stack.Push(0);
            stack.Push(1);
            ulong second = 0;
            ulong first = 0;
            ulong toAdd = 0;
            for (ulong i = 1; i < num; i++)
            {                
                toAdd = stack.Pop();
                first = stack.Peek();
                stack.Push(toAdd);
                second = stack.Peek();
                stack.Push(second+first);
                //Console.WriteLine("Added num:{0}", second+first);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
