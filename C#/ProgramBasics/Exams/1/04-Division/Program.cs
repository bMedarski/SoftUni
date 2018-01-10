using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Division
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int countTwo = 0;
            int countThree = 0;
            int countFour = 0;
            int x = 0;

            for (int i=0; i<n; i++)
            {
                x = int.Parse(Console.ReadLine());
                if (x % 2==0)
                {
                    countTwo++;
                }
                if (x % 3 == 0)
                {
                    countThree++;
                }
                if (x % 4 == 0)
                {
                    countFour++;
                }
            }
            double p1 = (double)countTwo / n * 100;
            double p2 = (double)countThree / n * 100;
            double p3 = (double)countFour / n * 100;

            


          Console.WriteLine("{0:F2}%", p1);
         Console.WriteLine("{0:F2}%", p2);
           Console.WriteLine("{0:F2}%", p3);
        }
    }
}
