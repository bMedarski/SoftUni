using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {


            long dayCount = long.Parse(Console.ReadLine());   //365
            long runnersCount = long.Parse(Console.ReadLine());   //int
            long averageLaps = long.Parse(Console.ReadLine());    //100
            long trackLength = long.Parse(Console.ReadLine());    //int
            long trackCapacity = long.Parse(Console.ReadLine());  //1000
            decimal moneyPerKilo = decimal.Parse(Console.ReadLine());
            long runners = 0;
            ulong totalKilometers = 0;
            decimal moneyRaised = 0;

            long maxCapacity = trackCapacity * dayCount;
           

            if (maxCapacity < runnersCount)
            {
                runners = maxCapacity;
            }else
            {
                runners = runnersCount; //365000
            }
            //Console.WriteLine(runners);

            totalKilometers = (ulong)(runners * averageLaps * trackLength)/1000;
            moneyRaised = (totalKilometers * moneyPerKilo);
            
            Console.WriteLine($"Money raised: {moneyRaised:F2}");
        }
    }
}
