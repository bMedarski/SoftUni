using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else if(input[i] == ')')
                {
                    if (stack.Count > 0 && stack.Peek()=='(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(input[i]);
                        Console.WriteLine("NO");
                        break;
                    }
                }
                else if (input[i] == '}')
                {
                    if (stack.Count > 0&&stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(input[i]);
                        Console.WriteLine("NO");
                        break;
                    }
                }
                else if (input[i] == ']')
                {
                    if (stack.Count > 0 && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(input[i]);
                        Console.WriteLine("NO");
                        break;
                    }
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            //else
            //{
            //    Console.WriteLine("NO");

            //}

        }
    }
}
