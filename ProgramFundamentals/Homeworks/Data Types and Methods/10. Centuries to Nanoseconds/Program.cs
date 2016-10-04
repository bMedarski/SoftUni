using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _1.Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {

            int centures = int.Parse(Console.ReadLine());

            int years = centures * 100;
            long days = (int)(years * 365.2422);
            long hours = days * 24;
            ulong minutes = (ulong)hours * 60;
            BigInteger seconds = minutes * 60;
            BigInteger milliseconds = seconds * 1000;
            BigInteger microseconds = milliseconds * 1000;
            BigInteger nanoseconds = microseconds * 1000;



            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", centures, years, days, hours, minutes,seconds, milliseconds, microseconds, nanoseconds);

        }
    }
}
