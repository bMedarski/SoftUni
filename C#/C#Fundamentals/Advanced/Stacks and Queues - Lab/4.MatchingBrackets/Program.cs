using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            var stack = new Stack<int>();
            var length = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    stack.Push(i);
                }else if (input[i] == ')')
                {
                    length = i - stack.Peek() + 1;
                    Console.WriteLine(input.Substring(stack.Peek(),length));
                    stack.Pop();
                }
            }

        }
    }
}
