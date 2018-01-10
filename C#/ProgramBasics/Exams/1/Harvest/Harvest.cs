using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {

            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grozde = (x * 40 / 100)*y;
            double vino = grozde / 2.5;

            if (z>vino)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor((z-vino)));
            }
            else
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(vino));
                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(vino-z), Math.Ceiling((vino-z)/workers));
            }
        }
    }
}
