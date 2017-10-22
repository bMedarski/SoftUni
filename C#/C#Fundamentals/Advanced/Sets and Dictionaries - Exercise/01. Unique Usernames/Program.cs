using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            var count = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                if (dict.ContainsKey(input))
                {
                    dict[input]++;
                }
                else
                {
                    dict.Add(input, 1);
                }
            }
            foreach (var i in dict)
            {
                Console.WriteLine(i.Key);
            }
        }
    }
}