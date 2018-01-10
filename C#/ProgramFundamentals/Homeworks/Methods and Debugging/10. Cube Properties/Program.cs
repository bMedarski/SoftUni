using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            switch (parameter)
            {
                case "face":
                    Face(side);
                    break;
                case "space":
                    Space(side);
                    break;
                case "area":
                    Area(side);
                    break;
                case "volume":
                    Volume(side);
                    break;
            }

        }
        static void Face(double side)
        {
            double face = (double)side * Math.Sqrt(2);
            Console.WriteLine("{0:F2}",face);
        }
        static void Volume(double side)
        {
            double volume = (double)side * side * side;
            Console.WriteLine("{0:F2}", volume);
        }
        static void Space(double side)
        {
            double space = (double)side * Math.Sqrt(3);
            Console.WriteLine("{0:F2}", space);
        }
        static void Area(double side)
        {
            double area = (double)side * side * 6;
            Console.WriteLine("{0:F2}", area);
        }
    }
}
