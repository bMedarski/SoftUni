using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Variable_in_Hex_Format
{
    class Program
    {
        static void Main(string[] args)
        {

            string num = Console.ReadLine();
            int x = Convert.ToInt32(num, 16);
            Console.WriteLine(x);
        }
    }
}
