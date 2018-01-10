using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01.Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {

            // DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int[] date = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            DateTime theDate = new DateTime(date[2],date[1],date[0]);


            Console.WriteLine(theDate.DayOfWeek);
        }
    }
}
