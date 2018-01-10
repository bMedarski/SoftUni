using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {

            long x = long.Parse(Console.ReadLine());
            isPrime(x);
        }
        static void isPrime(long n)
        {
            bool isPrime = n > 1;
            double limit = Math.Sqrt(n);

            for (long i = 2; i <= limit; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
