using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrayOne = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arrayTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int len1 = arrayOne.Length,
                len2 = arrayTwo.Length,
                lenght = 0,
                diff = 0,
                lowLength;
           
            if (len1 >= len2)
            {
                lenght = len1;
                lowLength = len2;

            }
            else
            {
                lenght = len2;
                lowLength = len1;
            }
                int[] sumArray= new int[lenght];
                for (int i = 0; i< lenght; i++)
                {
                //if (diff == lowLength)
                //{
                //    diff = 0;
                //}
                //    sumArray[i] = arrayOne[i] + arrayTwo[diff];
                //    diff++;
                sumArray[i] = arrayOne[i% len1] + arrayTwo[i% len2];
            }
          
                Console.Write(String.Join(" ", sumArray));     
        }
    }
}
