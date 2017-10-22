//2 + 5 + 10 - 2 - 1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var split = input.Split(' ').Reverse().ToArray();
            var stack = new Stack<string>(split);
            var sum = int.Parse(stack.Pop());
            var number = 0;
            
            for (int i = 0; i < split.Length/2; i++)
            {
                if (stack.Peek() == "+")
                {
                    stack.Pop();
                    number = int.Parse(stack.Pop());
                    sum += number;
                }
                else
                {
                    stack.Pop();
                    number = int.Parse(stack.Pop());
                    sum -= number;
                }
            }

            //2 + 5 + 10 - 2 - 1
            Console.WriteLine(sum);
                    
        }
    }
}
