using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pointInFigure
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if ((x > 12) || (x<2))
            {
                Console.WriteLine("out");
            }
            else if ((y > 3) || (y < -5))
            {
                Console.WriteLine("out");
            }
            else if ((x < 4) && (y < -3))
            {
                Console.WriteLine("out");
            }
            else if ((x > 10) && (y < -3))
            {
                Console.WriteLine("out");
            }
            else if ((x < 4) && (y > 1))
            {
                Console.WriteLine("out");
            }
            else if ((x > 10) && (y > 1))
            {
                Console.WriteLine("out");
            }
            else
            {
                Console.WriteLine("in");
            }


        }
    }
}
