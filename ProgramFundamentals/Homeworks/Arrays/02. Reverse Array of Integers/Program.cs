using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i<n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = n-1; i>=0; i--)
            {
                Console.Write("{0} ",array[i]);
            }
        }
    }
}
