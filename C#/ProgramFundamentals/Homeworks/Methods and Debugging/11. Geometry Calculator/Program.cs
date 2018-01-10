using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string figure = Console.ReadLine();

            switch (figure)
            {
                case "triangle":
                    double sideTriangle = double.Parse(Console.ReadLine());
                    double heightTriangle = double.Parse(Console.ReadLine());
                    TriangleArea(sideTriangle,heightTriangle);
                    break;
                case "rectangle":
                    double widthRect = double.Parse(Console.ReadLine());
                    double heightRect = double.Parse(Console.ReadLine());
                    RectOrSquareArea(widthRect,heightRect);
                    break;
                case "square":
                    double sideSquare = double.Parse(Console.ReadLine());
                    RectOrSquareArea(sideSquare,sideSquare);
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    CircleArea(radius);
                    break;
            }
        }
        static void CircleArea(double r)
        {
            double area = Math.PI * (double)(r * r);
            Console.WriteLine("{0:F2}", area);
        }
        static void RectOrSquareArea(double a, double b)
        {
            double area = a * b;
            Console.WriteLine("{0:F2}", area);
        }static void TriangleArea(double side, double height)
        {
            double area = side * height / 2;
            Console.WriteLine("{0:F2}", area);
        }
    }
}
