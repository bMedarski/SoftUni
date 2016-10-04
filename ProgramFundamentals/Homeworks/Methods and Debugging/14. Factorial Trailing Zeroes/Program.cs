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
            FactorialCountZeros(n);


        }
        static void FactorialCountZeros(int n)
        {
            BigInteger factorial = 1;
            int countZeros = 0;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            
            while (factorial>0)
            {
                if (factorial%10==0)
                {
                    countZeros++;
                    factorial /= 10;
                }else
                {
                    break;
                }
            }



            Console.WriteLine(countZeros);
        }
    }
}
