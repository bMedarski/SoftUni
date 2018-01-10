using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Circles_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstCircle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondCircle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Circle first = new Circle() { X = firstCircle[0], Y = firstCircle[1], R = firstCircle[2] };
            Circle second = new Circle() { X = secondCircle[0], Y = secondCircle[1], R = secondCircle[2] };
            //int distance = first.R+second.R;
            double distance = GetDistance(first, second);
            if (distance> first.R + second.R)
            {
                Console.WriteLine("No");
            }else
            {
                Console.WriteLine("Yes");
            }

        }

        private static double GetDistance(Circle first, Circle second)
        {
            double a = (double)(Math.Abs(first.X - second.X));
            double b = (double)(Math.Abs(second.Y - first.Y));
            return Math.Sqrt(a * a + b * b);
        }
    }
        class Circle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int R { get; set; }
        }    
}
