using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {

            var guests = new SortedSet<string>();
            var state = "INVITE";
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "PARTY" || state== "PARTY")
                {
                    state = "PARTY";
                    guests.Remove(input);
                }
                else if (state == "INVITE")
                {
                    guests.Add(input);
                }               
            }
            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
