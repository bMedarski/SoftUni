using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double first = DistancePointToCenter(x1,y1);
            double second = DistancePointToCenter(x2,y2);

            if (first<=second)
            {
                Console.WriteLine("({0}, {1})",x1,y1);
            }else
            {
                Console.WriteLine("({0}, {1})", x2, y2);
            }
        }
        static double DistancePointToCenter(double a, double b)
        {
            double dx = a - 0;
            double dy = b - 0;

            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }
    }
}
