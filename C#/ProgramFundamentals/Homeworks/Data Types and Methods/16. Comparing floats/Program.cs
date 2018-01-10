using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {


            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            if ((num1-num2>eps)||(num2-num1>eps))
            {
                Console.WriteLine("False");
            }else
            {
                Console.WriteLine("True");

            }
        }
    }
}
