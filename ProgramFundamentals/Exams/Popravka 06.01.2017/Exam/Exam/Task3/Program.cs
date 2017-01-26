using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine().Split().ToArray();
            double[] track = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            long[] checkPoints = Console.ReadLine().Split().Select(long.Parse).ToArray();
            bool isFuelOut = false;
            double fuel = 0;
            foreach (var racer in racers)
            {
                isFuelOut = false;
                fuel = getStartingFuel(racer);

                for (int i = 0; i < track.Length; i++)
                {
                    if(checkPoints.Contains(i))
                    {
                        fuel += track[i];
                    }else
                    {
                        fuel -= track[i];
                    }
                    if (fuel<=0)
                    {
                        Console.WriteLine($"{racer} - reached {i}");
                        isFuelOut = true;
                        break;
                    }
                    //Console.WriteLine($"{racer}- fuel left {fuel:f2}");

                }
                if (!isFuelOut)
                {
                   Console.WriteLine($"{racer} - fuel left {fuel:f2}");
                }
                
            }
        }
        private static double getStartingFuel(string racer)
        {
            double startingFuel = racer[0];
            //Console.WriteLine(fuel);
            return startingFuel;
        }
    }
}
