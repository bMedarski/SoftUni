using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Tripple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            ulong[] input = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();
            ulong   a,
                    b;
            bool isTrue = false;


            for (long i = 0; i < input.Length; i++)
            {
                a = input[i];
                for (long j = 0; j < input.Length; j++)
                {
                    if (j > i)
                    {
                        b = input[j];

                        ulong sum = a + b;
                        if (input.Contains(sum))
                        {
                            Console.WriteLine("{0} + {1} == {2}", a, b, sum);
                            isTrue = true;
                        }
                        //for (long n = 0; n < input.Length; n++)
                        //{
                        //    if (n != i && n != j)
                        //     {
                        //    if ((a + b) == input[n])
                        //    {
                        //        Console.WriteLine("{0} + {1} == {2}", a, b, input[n]);
                        //        isTrue = true;
                        //    }
                        //    }
                        //}
                    }
                }
            }


            if (!isTrue)
            {
                Console.WriteLine("No");
            }
        }
    }
}
