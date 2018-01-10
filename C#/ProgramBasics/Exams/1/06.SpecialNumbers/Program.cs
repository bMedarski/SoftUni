using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i<=9999; i++)
            {
                int firstnum = i / 1000;
                int secondnum = (i % 1000) / 100;
                int thirdnum = ((i % 1000) % 100) / 10;
                int forthnum = i % 10;
                if ((firstnum == 0) || (secondnum == 0) || (thirdnum == 0) || (forthnum == 0))
                {
                }
                else
                {
                    if ((n % firstnum == 0) && (n % secondnum == 0) && (n % thirdnum == 0) && (n % forthnum == 0))
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }

            //int x = 1234;
            //int firstNum = x / 1000;
            //int secondNum = (x % 1000) / 100;
            //int thirdNum = ((x % 1000) % 100) / 10;
            //int forthNum = x % 10;
            //Console.WriteLine(firstNum);
            //Console.WriteLine(secondNum);
            //Console.WriteLine(thirdNum);
            //Console.WriteLine(forthNum);


        }
    }
}
