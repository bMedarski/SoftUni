using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Trip
{
    class Program
    {
        static void Main(string[] args)
        {

            double budjet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (season=="winter")
            {
                if (budjet<=100)
                {
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Hotel - {0:F2}",budjet*0.7);

                }
                else if (budjet <= 1000&&budjet>100)
                {
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Hotel - {0:F2}", budjet * 0.8);
                }
                else
                {
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine("Hotel - {0:F2}", budjet * 0.9);
                }

            }else
            {
                if (budjet <= 100)
                {
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Camp - {0:F2}", budjet * 0.3);

                }
                else if (budjet <= 1000 && budjet > 100)
                {
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Camp - {0:F2}", budjet * 0.4);
                }
                else
                {
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine("Hotel - {0:F2}", budjet * 0.9);
                }
            }
        }
    }
}
