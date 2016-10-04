using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i<array.Length; i++)
            {
                sum += ReverseNumber(array[i]);
                
            }
            Console.WriteLine(sum);
        }
        static int ReverseNumber(int n)
        {
            int r = 0;  
            int left = n;
            int rev = 0;
            while (left > 0)
            {
                r = left % 10;
                rev = rev * 10 + r;
                left = left / 10;  //left = Math.floor(left / 10); 
            }
            return rev;


        }
    }
}
