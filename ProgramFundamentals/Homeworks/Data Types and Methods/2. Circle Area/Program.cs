using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Circle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double diametar = Math.PI * radius * radius;

            Console.WriteLine("{0:F12}",diametar);

        }
    }
}
