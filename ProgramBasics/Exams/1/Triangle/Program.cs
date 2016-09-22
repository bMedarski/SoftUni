using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());

            double a = 0;
            double h = 0;
            if (x2>x3)
            {
                a = x2 - x3;
            }
            else
            {
                a = x3 - x2;
            }
            if (y1 > y2)
            {
                h = y1 - y2;
            }
            else
            {
                h = y2 - y1;
            }
            double s = a * h / 2;
            Console.WriteLine(s);
        }
    }
}
