using System;
using System.Numerics;
namespace Task1
{
    class Program
    {
        static void Main()
        {

            string departureTime = Console.ReadLine();
            int step = int.Parse(Console.ReadLine());
            int stepTime = int.Parse(Console.ReadLine());

            BigInteger secondsToAdd = step * stepTime;
            double seconds = (double)secondsToAdd;

            DateTime convertedToDate = DateTime.ParseExact(departureTime, "HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture);

            DateTime arrivalTime = convertedToDate.AddSeconds(seconds);

            Console.WriteLine("Time Arrival: {0:D2}:{1:D2}:{2:D2}", arrivalTime.Hour, arrivalTime.Minute,arrivalTime.Second);
        }
    }
}
