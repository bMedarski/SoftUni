using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {

            int restTime = int.Parse(Console.ReadLine());

            int leftRestTime = 30000 - (restTime * 127) - ((365 - restTime) * 63);
            int hours = leftRestTime / 60;
            double minutes = leftRestTime - hours * 60;

            if (leftRestTime>=0)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play",hours,minutes);
            }else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hours*-1, minutes*-1);

            }

        }
    }
}
