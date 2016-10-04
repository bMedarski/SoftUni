using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            MathPower(a,b);
        }
        static void MathPower(double a, double b)
        {
            Console.WriteLine(Math.Pow(a,b));
        }
    }
}
