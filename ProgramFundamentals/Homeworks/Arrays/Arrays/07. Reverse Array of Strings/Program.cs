using System;
using System.Linq;
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Console.WriteLine(String.Join(" ", input.Reverse()));
        }
    }
