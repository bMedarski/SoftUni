using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {

            double inheritance = double.Parse(Console.ReadLine());
            int yearToLive = int.Parse(Console.ReadLine());
            int currentYear = 1800;
            int age = 18;
            // start year 1800

            while (currentYear <= yearToLive)
            {
                if (currentYear%2==0)
                {
                    inheritance -= 12000;
                    age += 1;
                    currentYear += 1;
                }
                else
                {
                    inheritance -= 12000 + 50 * age;
                    age += 1;
                    currentYear += 1;
                }
            }
            if (inheritance>=0)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:F2} dollars left.",inheritance);
            }
            else
            {
                Console.WriteLine("He will need {0:F2} dollars to survive.", inheritance*-1);
            }

        }
    }
}
