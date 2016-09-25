using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            long n = long.Parse(Console.ReadLine());
            bool[] e = new bool[n];//by default they're all false
            for (int i = 2; i < n; i++)
            {
                e[i] = true;//set all numbers to true
            }
            //weed out the non primes by finding mutiples 
            for (int j = 2; j < n; j++)
            {
                if (e[j])//is true
                {
                    for (long p = 2; (p * j) < n; p++)
                    {
                        e[p * j] = false;
                    }
                }
            }
            for (int i = 2; i < n; i++)
            {
                if (e[i])
                {
                    Console.Write("{0} ",i);
                }
            }
        }
    }
}
