using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var chars = input.Select(c => (int)c).Select(c => $@"\u{c:x4}");

            var result = string.Concat(chars);
            Console.WriteLine(result);
        }
    }
}
