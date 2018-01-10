using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Distance_between_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstPoint = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondPoint = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Point first = new Point();
            Point second = new Point();
            first.X = firstPoint[0];
            first.Y = firstPoint[1];
            second.X = secondPoint[0];
            second.Y = secondPoint[1];
            CalcDistance(first, second);
        }

        private static void CalcDistance(Point first, Point second)
        {

            double distance = Math.Sqrt
                ((Math.Abs((first.X-second.X)*(first.X - second.X)))+
                (Math.Abs((first.Y - second.Y) * (first.Y - second.Y))));
            Console.WriteLine("{0:F3}",distance);
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}
