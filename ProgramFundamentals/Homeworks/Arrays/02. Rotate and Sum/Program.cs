using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            int[] sum = new int[array.Length];
            int[] rotated = new int[array.Length];
            //rotated[0] = array[array.Length - 1];
            //sum[0] += rotated[0];
            while (k > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == 0)
                    {
                        rotated[0] = array[array.Length - 1];
                        sum[0] += rotated[0];
                    }
                    else
                    {
                        rotated[i] = array[i - 1];
                        sum[i] += rotated[i];
                    }
                }
                array = (int[])rotated.Clone();
                k--;

            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", sum[i]);
                //console.writeline();
            }


        }
    }
}

