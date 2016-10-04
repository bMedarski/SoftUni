using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int charOne = int.Parse(Console.ReadLine());
            int charTwo = int.Parse(Console.ReadLine());


            for (int counter = charOne; counter <= charTwo; counter++)
            {
                Console.Write("{0} ",(char)counter);
            }
        }
    }
}
