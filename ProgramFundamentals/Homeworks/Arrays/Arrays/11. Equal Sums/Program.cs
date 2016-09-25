using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool isFindNumber = false;
            
            for (int i = 0; i < array.Length; i++)
            {

                if (LeftSum(array,i)==RigthSum(array,i))
                {
                    Console.WriteLine(i);
                    isFindNumber = true;
                }
            }
            if (!isFindNumber)
            {
                Console.WriteLine("no");
            }


        }
        static int LeftSum(int[] array, int index)
        {
            int sum = 0;

            for (int i = 0; i< index; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        static int RigthSum(int[] array, int index)
        {
            int sum = 0;

            for (int i = index+1; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
