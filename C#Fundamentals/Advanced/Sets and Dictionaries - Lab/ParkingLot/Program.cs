using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {

            var plates = new SortedSet<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else
                {
                    var plate = input.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (plate[0] == "IN")
                    {
                        plates.Add(plate[1]);
                    }else if (plate[0] == "OUT")
                    {
                        plates.Remove(plate[1]);
                    }
                }
               
            }
            if (plates.Count > 0)
            {
                foreach (var plate in plates)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
