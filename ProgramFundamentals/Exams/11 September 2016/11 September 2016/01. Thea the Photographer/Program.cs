using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {



            int pictureAmount = int.Parse(Console.ReadLine());
            int filterSeconds = int.Parse(Console.ReadLine());
            int percentOfGood = int.Parse(Console.ReadLine());
            int uploadSeconds = int.Parse(Console.ReadLine());

            long totalTime = pictureAmount * (long)filterSeconds;
            double percentage = percentOfGood / 100.0;
            double okPictures = Math.Ceiling(pictureAmount * percentage );

            totalTime += (int)okPictures * (long)uploadSeconds;

            //86400
            //TimeSpan time = new TimeSpan(0,0,0,totalTime);
            //Console.WriteLine(time.ToString(@"dd\:hh\:mm\:ss"));

            //Console.WriteLine(
              //  TimeSpan.FromSeconds(totalTime)
             //       .ToString(new string('d', 1) + @"\:hh\:mm\:ss"));
             long days = (totalTime / 86400);
            //Console.WriteLine(totalTime % 86400);
              totalTime = (totalTime % 86400);
            //Console.WriteLine(totalTime);
              long hours = (totalTime / 3600);

            totalTime = totalTime % 3600;

             long minutes = (totalTime / 60);

             long seconds = (totalTime % 60);

            Console.WriteLine("{0}:{1}:{2}:{3}", days, hours.ToString().PadLeft(2, '0'), minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));


        }
    }
}
