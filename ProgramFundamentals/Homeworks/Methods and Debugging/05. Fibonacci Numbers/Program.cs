using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = int.Parse(Console.ReadLine());
            Fibonacci(x);

        }
        static void Fibonacci(int n)
        {
            if (n == 1) { Console.WriteLine(1); }
            else if (n==0)
            {
                Console.WriteLine(1);
            }
            else
            {
                int first = 1;
                int second = 1;
                int current = 0;
                for (int i = 2; i <= n; i++)
                {
                    current = first + second;
                    first = second;
                    second = current;
                }
                Console.Write(current);
            }
        }
    }
}
