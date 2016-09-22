using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {


            int countBricks = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int wheelCapacity = int.Parse(Console.ReadLine());

            int brickOnCourse = workers * wheelCapacity;

            int countCourse = countBricks / brickOnCourse;
            if (countBricks%brickOnCourse!=0)
            {
                countCourse += 1;
            }
            Console.WriteLine(countCourse);
        }
    }
}
