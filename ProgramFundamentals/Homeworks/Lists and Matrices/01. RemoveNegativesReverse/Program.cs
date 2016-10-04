using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RemoveNegativesReverse
{
    class Program
    {
        static void Main(string[] args)
        {

            int[]  nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> listOfPossitive = new List<int>();

            for (int i = 0; i<nums.Length; i++)
            {
                if (nums[i]>=0)
                {
                    listOfPossitive.Add(nums[i]);
                }
            }          
            listOfPossitive.Reverse();
            if (listOfPossitive.Count>0)
            {
                Console.WriteLine(string.Join(" ", listOfPossitive));
            }else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
