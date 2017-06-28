using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CharMultpl
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(' ').ToArray();
            var first = input[0];
            var second = input[1];
            var left = "";
            var lenght = Math.Min(first.Length, second.Length);
            var sum = 0;

            for (int i = 0; i < lenght; i++)
            {
                sum += ((int) first[i]) * ((int) second[i]);
            }
            if (first.Length > second.Length)
            {
                left = first.Substring(lenght);
            }
            else if (first.Length < second.Length)
            {
                left = second.Substring(lenght);
            }
            for (int i = 0; i < left.Length; i++)
            {
                sum += (int) left[i];
            }
            Console.WriteLine(sum);
        }
    }
}
