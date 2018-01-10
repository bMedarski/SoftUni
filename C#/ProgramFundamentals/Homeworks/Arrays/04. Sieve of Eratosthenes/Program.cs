using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            ulong n = ulong.Parse(Console.ReadLine());
            bool[] e = new bool[n+1];//by default they're all false
            for (ulong i = 2; i <= n; i++)
            {
                e[i] = true;//set all numbers to true
            }
            //weed out the non primes by finding mutiples 
            for (ulong j = 2; j <= n; j++)
            {
                if (e[j])//is true
                {
                    for (ulong p = 2; (p * j) <= n; p++)
                    {
                        e[p * j] = false;
                    }
                }
            }
            for (ulong i = 2; i <= n; i++)
            {
                if (e[i])
                {
                    Console.Write("{0} ",i);
                }
            }
        }
    }
}
