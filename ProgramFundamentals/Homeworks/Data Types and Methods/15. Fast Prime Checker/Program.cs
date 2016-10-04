using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCheckSoftUni_20._05._2016
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            for (long i=2;i<=n;i++) {
                Console.WriteLine("{0} -> {1}",i,IsPrime(i));
            }

            
        }

        static bool IsPrime(long n)
        {
            int sqrtN = (int)Math.Sqrt(n);
            if (n <= 1)
            {
                return false;
            }
            else if (n > 2)
            {
                for (int cnt = 2; cnt <= sqrtN; cnt++)
                {
                    if (n % cnt == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}