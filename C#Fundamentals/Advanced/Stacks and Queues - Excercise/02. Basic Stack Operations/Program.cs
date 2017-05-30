using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var elementsCount = input[0];
            var elementsToPop = input[1];
            var elementToCheck = input[2];

            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>(elements);
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }

        }
    }
}

