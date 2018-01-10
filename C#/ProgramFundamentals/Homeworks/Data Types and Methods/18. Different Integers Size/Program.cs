using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {


            BigInteger x = BigInteger.Parse(Console.ReadLine());


            if (x > 9223372036854775807 || x < -9223372036854775808)
            {
               // 213333333333333333333333333333333333
                Console.WriteLine("{0} can't fit in any type", x);
            }
            else
            {
                Console.WriteLine("{0} can fit in:", x);

                if (x <= 128 && x >= -128)
                {
                    Console.WriteLine("* sbyte");
                }
                if (x <= 255 && x >= 0)
                {
                    Console.WriteLine("* byte");
                }
                if (x <= 32767 && x >= -32768)
                {
                    Console.WriteLine("* short");
                }
                if (x <= 65535 && x >= 0)
                {
                    Console.WriteLine("* ushort");
                }
                if (x <= 2147483647 && x >= -2147483648)
                {
                    Console.WriteLine("* int");
                }
                if (x <= 4294967295 && x >= 0)
                {
                    Console.WriteLine("* uint");
                }
                if (x <= 9223372036854775807 && x >= -9223372036854775808)
                {
                    Console.WriteLine("* long");
                }
            }
        }
    }
}
