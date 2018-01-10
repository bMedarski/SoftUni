using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Factorial(n);


        }
        static void Factorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i<=n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
