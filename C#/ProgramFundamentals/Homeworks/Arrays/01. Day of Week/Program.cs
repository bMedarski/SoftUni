using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int x = int.Parse(Console.ReadLine());

            if (x<1||x>7) {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(weekDays[x-1]);
            }
        }
    }
}
