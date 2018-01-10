using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] nums = Console.ReadLine().Split('|').ToArray();
            List<int> finalList = new List<int>();
            char[] splitters = { ' ' };
            for (int i = nums.Length-1; i>=0; i--)
            {

                int[] splittedNums = nums[i].Split(splitters, System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (int num in splittedNums)
                {
                    finalList.Add(num);
                }

            }
            Console.WriteLine(string.Join(" ",finalList));


        }
    }
}
