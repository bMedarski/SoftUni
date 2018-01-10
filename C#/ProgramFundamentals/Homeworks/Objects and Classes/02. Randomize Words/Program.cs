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
            List<string> array = Console.ReadLine().Split(' ').ToList();
            string[] newArray = new string[array.Count];
            Random x = new Random();
            int index = 0;
            int length = array.Count;
            for (int i = 0; i< length; i++)
            {
                index = x.Next(0, array.Count - 1);
                Console.WriteLine(array[index]);
                array.RemoveAt(index);

            }

        }
    }
}
