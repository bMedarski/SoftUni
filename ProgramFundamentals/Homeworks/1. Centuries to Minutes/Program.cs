using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("{0} centures = {1} years = {2} days = {3} hours = {4} minutes",centures,years,days,hours,minutes);

        }
    }
}
