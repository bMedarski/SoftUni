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
            bool isEqual = true;
            int lenght = 0;

            if (first.Length <= second.Length)
            {
                 lenght = first.Length;
            }else
            {
                 lenght = second.Length;
            }

            for (int i = 0; i < lenght; i++)
            {
                if (first[i] < second[i])
                {
                    Print(first);
                    Console.WriteLine();
                    Print(second);
                    isEqual = false;
                    break;
                }
                else if(first[i] > second[i])
                {
                    Print(second);
                    Console.WriteLine();
                    Print(first);
                    isEqual = false;
                    break;
                }
            }
            if (isEqual)
            {
                if (first.Length <= second.Length)
                {
                    Print(first);
                    Console.WriteLine();
                    Print(second);
                }else
                {
                    Print(second);
                    Console.WriteLine();
                    Print(first);
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
