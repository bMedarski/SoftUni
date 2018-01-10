using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {

            int neededHours = int.Parse(Console.ReadLine());
            int availableDays = int.Parse(Console.ReadLine());
            int overTimeWorkers = int.Parse(Console.ReadLine());

            double availableHours  = ((double)availableDays * 0.9)*8;
            //Console.WriteLine(availableHours);
            double sumHours = availableHours + (overTimeWorkers * 2 * availableDays);
           // Console.WriteLine(sumHours);
            sumHours = Math.Floor(sumHours);
            double leftHours = neededHours - sumHours;
            if (leftHours<0)
            {
                Console.WriteLine("Yes!{0} hours left.",leftHours*-1);
            }
            else if (leftHours==0)
            {
                Console.WriteLine("Yes!{0} hours left.", leftHours * -1);
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", leftHours);
            }



        }
    }
}
