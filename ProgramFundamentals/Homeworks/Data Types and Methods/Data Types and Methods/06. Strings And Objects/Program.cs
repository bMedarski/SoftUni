using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Strings_And_Objects
{
    class Program
    {
        static void Main(string[] args)
        {

            string first = "Hello";
            string second = "World";

            object name = first + " " + second;
            string third = (string)name;
            Console.WriteLine(third);
        }
    }
}
