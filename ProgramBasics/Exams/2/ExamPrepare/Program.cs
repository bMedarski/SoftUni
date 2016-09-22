using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrepare
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(input);
            int sum = 0;
            double average = 0;
            int count = 0;
            for (int i = 0; i<input.Length;i++)
            {
                sum += input[i];
            }
            average = (double)sum / input.Length;

            if (input.Length>=5)
            {
                for (int i = input.Length - 1; i > input.Length - 6; i--)
                {
                    if (input[i] > average)
                    {

                        Console.Write("{0} ", input[i]);
                        count++;
                    }
                }

            }
            else
            {
                for (int i = input.Length - 1; i >=0; i--)
                {
                    if (input[i] > average)
                    {

                        Console.Write("{0} ", input[i]);
                        count++;
                    }
                }
            }
           
            if (count==0)
            {
                Console.Write("No");
            }
            
        }
    }
}
