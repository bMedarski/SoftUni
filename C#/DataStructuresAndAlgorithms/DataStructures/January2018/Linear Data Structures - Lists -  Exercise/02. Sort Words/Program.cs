using System;
using System.Linq;

namespace _02._Sort_Words
{
    class Program
    {
        static void Main()
        {
	        var list = Console.ReadLine().Split().ToList();
			Console.WriteLine(String.Join(" ",list.OrderBy(a=>a)));
        }
    }
}
