using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();            
            char[] array = input.ToCharArray();
            for (int i = 0; i<array.Length; i++)
            {
                PrintIndexOfLetter(array[i]);
            }


        }
        static void PrintIndexOfLetter(char x)
        {
            char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (x==alphabet[i])
                {
                    Console.WriteLine("{0} -> {1}",x,i);
                }
            }
        }
    }
}
