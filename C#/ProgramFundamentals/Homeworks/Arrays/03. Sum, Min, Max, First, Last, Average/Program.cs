using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace _03.Sum__Min__Max__First__Last__Average
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            //int sum = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                //sum += array[i];
            }
            int sum = array.Sum();
            Console.WriteLine("Sum = {0}",sum);
            int min = array.Min();
            Console.WriteLine("Min = {0}", min);
            int max = array.Max();
            Console.WriteLine("Max = {0}", max);
            int first = array.First();
            Console.WriteLine("First = {0}", first);
            int last = array.Last();
            Console.WriteLine("Last = {0}", last);
            double average = array.Average();
            Console.WriteLine("Average = {0}", average);


        }
    }
}
