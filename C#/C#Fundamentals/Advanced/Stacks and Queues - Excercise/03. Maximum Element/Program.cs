using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04
{
    class Program
    {
        static Stack<int> stack = new Stack<int>();
        private static int max = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] args = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                ExecuteCommand(args);
            }
        }

        private static void ExecuteCommand(int[] args)
        {
            switch (args[0])
            {
                case 1:
                    stack.Push(args[1]);
                    if (args[1] > max)
                    {
                        max = args[1];
                    }
                    break;
                case 2:
                    int element = stack.Pop();
                    if (element == max && stack.Count > 0)
                    {
                        max = stack.Max();
                    }
                    else if (element == max && stack.Count == 0)
                    {
                        max = 0;
                    }
                    break;
                case 3:
                    Console.WriteLine(max);
                    break;
            }
        }
    }
}