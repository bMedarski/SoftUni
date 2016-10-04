using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Count_Numbers_Variation
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Dictionary<int, int> availableNums = new Dictionary<int, int>();

            nums.Sort();
            int count = 1;
            for (int i = 0; i< nums.Count;i++ )
            {
                if (!availableNums.ContainsKey(nums[i]))
                {
                    count = 1;
                    availableNums.Add(nums[i], count);
                }
                else
                {
                    count++;
                    availableNums[nums[i]] = count;
                }
            }
            List<int> list = new List<int>(availableNums.Keys);
            foreach (var item in list)
            {
                Console.WriteLine("{0} -> {1}", item, availableNums[item]);
            }


        }
    }
}
