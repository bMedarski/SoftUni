using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Closest_Two_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                int[] inputCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int x = inputCoordinates[0];
                int y = inputCoordinates[1];

                points[i] = new Point() { X = x, Y = y };

                
            }
            double lowestDistance = double.MaxValue;
            int one = 0;
            int two = 0;
            for (int i = 0; i < points.Length-1; i++)
            {
                for (int j = i+1; j < points.Length; j++)
                {
                    if (lowestDistance > CalcDistance(points[i], points[j]))
                    {
                        lowestDistance = CalcDistance(points[i], points[j]);
                        one = i;
                        two = j;
                    }                 
                }
            }
            Console.WriteLine("{0:F3}",lowestDistance);
            Console.WriteLine("({0}, {1})", points[one].X, points[one].Y);
            Console.WriteLine("({0}, {1})", points[two].X, points[two].Y);
        }
        private static double CalcDistance(Point first, Point second)
        {

            double distance = Math.Sqrt
                ((Math.Abs((first.X - second.X) * (first.X - second.X))) +
                (Math.Abs((first.Y - second.Y) * (first.Y - second.Y))));
            return distance;
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
