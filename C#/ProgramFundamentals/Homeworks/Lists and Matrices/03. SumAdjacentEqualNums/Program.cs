using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SumAdjacentEqualNums
{
    class Program
    {
        static void Main(string[] args)
        {

            List<double> nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            double currElement = nums[0];


            for (int i = 1; i< nums.Count; i++)
            {
                if (nums[i-1] == nums[i])
                {
                    nums[i-1]*=2;
                    nums.RemoveAt(i);                  
                    if (i>2)
                    {
                        i = i - 2;
                    }
                    else
                    {
                        i = 0;
                    }                    
                }
                else
                {
                    currElement = nums[i];
                }
            }
            Console.WriteLine(string.Join(" ",nums));

        }
        
    }
}
