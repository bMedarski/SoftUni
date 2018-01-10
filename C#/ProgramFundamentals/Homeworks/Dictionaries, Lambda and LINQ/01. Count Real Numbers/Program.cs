using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var nums = new SortedDictionary<double, int>();

            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i< numbers.Length; i++)
            {
                if (nums.ContainsKey(numbers[i]))
                {
                    nums[numbers[i]]++;
                }
                else
                {
                    nums[numbers[i]] = 1;
                }
            }
            foreach (var item in nums)
            {
                Console.WriteLine("{0} -> {1}",item.Key,item.Value );
            }
        }
    }
}
