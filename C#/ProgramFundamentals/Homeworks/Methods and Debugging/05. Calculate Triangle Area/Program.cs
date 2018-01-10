using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(TrianbleArea(width,height));

        }
        static double TrianbleArea(double a, double b)
        {

            double area = (a * b)/2;
            return area;
        } 
    }
}
