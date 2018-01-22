using System;
using System.Linq;

namespace _01._Sum_and_Average
{
    class Program
    {
	    static void Main()
	    {
		    var list = Console.ReadLine().Split().Select(int.Parse).ToList();
		    Console.WriteLine($"Sum={list.Sum()}; Average={list.Average():F2}");
	    }
    }
}
