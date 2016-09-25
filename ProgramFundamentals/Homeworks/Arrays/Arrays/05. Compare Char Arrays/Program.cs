using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] first = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] second = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] < second[i])
                {
                    Print(first);
                    Console.WriteLine();
                    Print(second);
                    break;
                }
                else
                {
                    Print(second);
                    Console.WriteLine();
                    Print(first);
                    break;
                }
            }

        }
        static void Print(char[] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                Console.Write("{0}", array[j]);
            }
        }
    }
}
