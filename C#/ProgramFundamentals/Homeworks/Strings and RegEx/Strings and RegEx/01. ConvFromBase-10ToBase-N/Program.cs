using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.ConvFromBase_10ToBase_N
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BigInteger[] numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            BigInteger num = numbers[1];

            BigInteger K = numbers[0];
            BigInteger remainder = 0;
            StringBuilder number = new StringBuilder();
            while (num != 0)
            {
                //101
                remainder = num % K;  // assume K > 1  5/2 = 10
                num = num / K;  // integer division
                number.Append(remainder);
            }
            Console.WriteLine(string.Join("",number.ToString().Reverse()));
        }
    }
}
