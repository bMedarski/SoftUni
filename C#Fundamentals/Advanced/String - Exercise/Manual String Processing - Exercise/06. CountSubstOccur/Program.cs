using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSubstOccur
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            var toSearch = Console.ReadLine().ToLower();
            var index = 0;
            var count = 0;
            while (input.IndexOf(toSearch,index)!=-1)
            {
                count++;
                index = input.IndexOf(toSearch, index) + 1;
            }
            Console.WriteLine(count);
        }
    }
}
