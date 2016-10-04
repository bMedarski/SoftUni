using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = 1,
                element = array[0],
                max = 0,
                maxElement = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                element = array[i];
                for (int j = i+1; j<array.Length; j++)
                {
                    if (element == array[j])
                    {
                        count++;
                        if (max<count)
                        {
                            max = count;
                            maxElement = element;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }                     
                Console.Write(maxElement);
        }
    }
}
