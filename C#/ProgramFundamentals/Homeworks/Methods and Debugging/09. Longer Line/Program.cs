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
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double first = DistancePoints(x1, y1,x2,y2);
            double second = DistancePoints(x3, y3,x4,y4);

            if (first > second)
            {
                double distanceFirstToCenter = DistancePointToCenter(x1,y1);
                double distanceSecondToCenter = DistancePointToCenter(x2, y2);
                if (distanceFirstToCenter<=distanceSecondToCenter)
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
                }
                else
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
                }
                
            }
            else
            {
                double distanceFirstToCenter = DistancePointToCenter(x3, y3);
                double distanceSecondToCenter = DistancePointToCenter(x4, y4);
                if (distanceFirstToCenter <= distanceSecondToCenter)
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", x3, y3, x4, y4);
                }
                else
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", x4, y4, x3, y3);
                }               
            }
        }
        static double DistancePoints(double a, double b, double c, double d)
        {
            double dx = a - c;
            double dy = b - d;

            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance;
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
