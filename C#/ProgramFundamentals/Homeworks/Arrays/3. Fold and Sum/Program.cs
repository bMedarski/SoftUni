using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = array.Length;
            int[] reworkedArray = new int[length / 2];


            
            for (int i=0; i<reworkedArray.Length; i++)
            {
                if (i< reworkedArray.Length/2)
                {
                    reworkedArray[i] = array[length / 4 + i] + array[length / 4 - 1 - i];
                }
                else
                {
                    reworkedArray[i] = array[length / 4 + i] + array[length  - i -1 + reworkedArray.Length/2];

                }
                
                Console.Write("{0} ",reworkedArray[i]);
            }
            
        }
    }
}
