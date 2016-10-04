using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintHeader(n);
            //Console.WriteLine();
            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddle(n);
                //Console.WriteLine();
            }
            PrintHeader(n);


        }
        static void PrintHeader(int n)
        {

            Console.WriteLine(new string('-', 2 * n));

        }
        static void PrintMiddle(int n)
        {
            Console.Write("-");
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }
    }
}
