using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int> liters = new Queue<int>();
            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] pumpDistance = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                liters.Enqueue(pumpDistance[0] - pumpDistance[1]);
            }
            int index = 0;
            long fuelAmounth = -1;
            for (int i = 0; i < numberOfPumps; i++)
            {
                if (liters.Peek() >= 0 && fuelAmounth < 0)
                {
                    index = i;
                    fuelAmounth = 0;
                }

                fuelAmounth += liters.Dequeue();
            }

            Console.WriteLine(index);
            ///////////////////////////////
            //    var pumpStations = int.Parse(Console.ReadLine());
            //    var fuel = -1;
            //    var counterStations = 0;

            //    CheckFuel(fuel, counterStations, pumpStations);
            //}

            //static void CheckFuel(int fuel, int currentStation,int allPumpstations)
            //{
            //        //Console.WriteLine("currentStation: {0}", currentStation);
            //       // Console.WriteLine("allPumpstations: {0}", allPumpstations);
            //    while (currentStation<allPumpstations-1)
            //    {

            //        //Console.WriteLine("stancia: {0}", currentStation);
            //        //Console.WriteLine("GOrivo: {0}", fuel);
            //        var station = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //        var neededFuel = station[0] - station[1];
            //        //Console.WriteLine("NEOBHODIMO GORIVO: {0}", neededFuel);
            //        if (neededFuel >= 0 && fuel < 0)
            //        {
            //            Console.WriteLine(currentStation);
            //        }
            //        currentStation++;
            //        fuel += neededFuel;
            //        CheckFuel(fuel, currentStation, allPumpstations);
            //    }
        }
    }
 }
