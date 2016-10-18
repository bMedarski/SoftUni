using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Work_Days
{
    class Program           //not working in judge
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(firstDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int workingDaysCount = 0;

            //Console.WriteLine(startDate);
           // Console.WriteLine(endDate);
            
            while (startDate<=endDate)
            {
                if (isWorkingDay(startDate))
                {
                    workingDaysCount++;
                }
                startDate = startDate.AddDays(1);
            }
            Console.WriteLine(workingDaysCount);
            //Console.WriteLine(startDate);
           // Console.WriteLine(endDate);

        }

        private static bool isWorkingDay(DateTime startDate)
        {
            int currentYear = startDate.Year;
            DayOfWeek day = startDate.DayOfWeek;
            List<DateTime> holidays = new List<DateTime>(){
            //holidays[0]= Convert.ToDateTime($"01/01/{currentYear}");
            //holidays[1] = Convert.ToDateTime($"03/03/{currentYear}");
            //holidays[2] = Convert.ToDateTime($"01/05/{currentYear}");
            //holidays[3] = Convert.ToDateTime($"06/05/{currentYear}");
            //holidays[4] = Convert.ToDateTime($"24/05/{currentYear}");
            //holidays[5] = Convert.ToDateTime($"06/09/{currentYear}");
            //holidays[6] = Convert.ToDateTime($"22/09/{currentYear}");
            //holidays[7] = Convert.ToDateTime($"01/10/{currentYear}");
            //holidays[8] = Convert.ToDateTime($"24/12/{currentYear}");
            //holidays[9] = Convert.ToDateTime($"25/12/{currentYear}");
            //holidays[10] = Convert.ToDateTime($"26/12/{currentYear}");

                new DateTime(currentYear, 01, 01),
                new DateTime(currentYear, 03, 03),
                new DateTime(currentYear, 01, 05),
                new DateTime(currentYear, 06, 05),
                new DateTime(currentYear, 24, 05),
                new DateTime(currentYear, 06, 09),
                new DateTime(currentYear, 22, 09),
                new DateTime(currentYear, 01, 10),
                new DateTime(currentYear, 24, 12),
                new DateTime(currentYear, 25, 12),
                new DateTime(currentYear, 26, 12)};
            for (int i = 0; i < holidays.Count; i++)
            {
                if (startDate == holidays[i])
                {
                    return false;
                }
            }
            if (day==DayOfWeek.Saturday||day==DayOfWeek.Sunday)
            {
                return false;
            }

            return true;
        }
    }
}
