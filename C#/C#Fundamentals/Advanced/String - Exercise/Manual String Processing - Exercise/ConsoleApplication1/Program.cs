using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var reversed = "";
            var sb = new StringBuilder();
            for (int i = input.Length; i > 0; i--)
            {
                sb.Append(input[i-1]);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
