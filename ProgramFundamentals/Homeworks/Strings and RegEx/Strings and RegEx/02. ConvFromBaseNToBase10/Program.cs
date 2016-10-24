using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.ConvFromBaseNToBase10
{
    class Program
    {
        static void Main(string[] args)
        {

            BigInteger[] numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            BigInteger num = numbers[1];

            BigInteger k = numbers[0];
            BigInteger remainder = 0;
            BigInteger index = 0;
            BigInteger sum = 0;
            while (num!=0)
            {
                remainder = num % 10;
                //BigInteger forSum = BigInteger.Multiply(num, BigInteger.Pow(new BigInteger(baseN), i));
                sum +=remainder*(ulong)(BigInteger.Pow(k,index));
                //Console.WriteLine(sum);
                index++;
                num /= 10;
            }
          
            Console.WriteLine(sum);
        }
    }
}
