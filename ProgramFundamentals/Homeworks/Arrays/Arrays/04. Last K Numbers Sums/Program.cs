using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.Last_K_Numbers_Sums
{
    class Program
    {
        static void Main(string[] args)
        {


            ulong n = ulong.Parse(Console.ReadLine());
            ulong k = ulong.Parse(Console.ReadLine());

            BigInteger[] array = new BigInteger[n];


            for (ulong i = 1; i<n; i++)
            {
                array[0] = 1;
                BigInteger currentSum = 0;
                for (ulong j = 1; j<=k; j++)
                {
                    try
                    {
                        currentSum += array[i-j];
                    }
                    catch
                    {
                        currentSum += 0;
                    }

               }           
                array[i] = currentSum;               
            }
            for (ulong i = 0; i<n; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            
        }
    }
}
