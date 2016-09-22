using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ').ToArray();
            string[] newArray = new string[array.Length];
            Random x = new Random();
            int length = array.Length;
            for (int i = 0; i< array.Length; i++)
            {
                //newArray[i] = array[x.Next(0,length-1)];
                Console.WriteLine(array[x.Next(0, length-1)]);
            }

        }
    }
}
