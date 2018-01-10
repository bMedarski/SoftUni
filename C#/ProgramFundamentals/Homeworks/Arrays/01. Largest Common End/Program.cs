using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input1 = Console.ReadLine().Split(' ').ToArray();
            string[] input2 = Console.ReadLine().Split(' ').ToArray();
            int count1 = 0,
                count2 = 0,
                max1 = 0,
                max2 = 0,
                i=0,
                j=0,
                length;



            if (input1.Length >= input2.Length)
            {
                length = input2.Length;
            }
            else
            {
                length = input1.Length;
            }
            //for (int i = 0; i < input1.Length; i++)
            //{

                //    for (int j = 0; j < input2.Length; j++)
                //    {


                //        if (input1[i] == input2[j])
                //        {
                //            count++;
                //            if (i < input1.Length - 1)
                //            {
                //                i++;
                //            }
                //            if (max < count)
                //            {
                //                max = count;
                //            }
                //        }
                //        else
                //        {
                //            count = 0;
                //        }
                //    }
                //}

                while (i < length)
            {
                if (input1[i]==input2[i])
                {
                    count1++;
                    if (max1<count1)
                    {
                        max1 = count1;
                    }
                }
                else
                {
                    count1 = 0;
                }
                i++;
            }
            while (j < length)
            {
                if (input1[input1.Length-j-1] == input2[input2.Length-j-1])
                {
                    count2++;
                    if (max2 < count2)
                    {
                        max2 = count2;
                    }
                }
                else
                {
                    count2 = 0;
                }
                j++;
            }
            Console.WriteLine(max1>=max2?max1:max2);
        }
    }
}
