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


            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger[] array = new BigInteger[n];

            array[0] = 1;
            for (int i = 1; i<n; i++)
            {
                //array[0] = 1;
                //var start = Math.Max(0,i-k);
                BigInteger currentSum = 0;
                for (int j = 1; j<=k; j++)
                {

                    if (i-j<0)
                    {
                        currentSum += 0;
                    }
                    else
                    {
                        currentSum += array[i-j];
                    }
                       
                   

               }           
                array[i] = currentSum;               
            }
            for (int i = 0; i<n; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            
        }
    }
}
