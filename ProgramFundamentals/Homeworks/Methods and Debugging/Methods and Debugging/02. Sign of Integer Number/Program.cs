using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sign_of_Integer_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            SignOfaNumber(n);
        }
        static void SignOfaNumber(int num)
        {
            if (num==0)
            {
                Console.WriteLine("The number 0 is zero.");
            }else if (num>0)
            {
                Console.WriteLine("The number {0} is positive.",num);
            }else
            {
                Console.WriteLine("The number {0} is negative.", num);
            }
        }
    }
}
