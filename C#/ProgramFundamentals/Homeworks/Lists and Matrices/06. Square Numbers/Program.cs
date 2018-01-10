using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> sqrtNums = new List<int>();
            foreach (var num in nums)
            {
                if (IsExactSqrt(num))
                {
                    sqrtNums.Add(num);
                }
            }
            sqrtNums.Sort();
            sqrtNums.Reverse();
            Console.WriteLine(string.Join(" ", sqrtNums));

        }
        static bool IsExactSqrt(int num)
        {
            if (Math.Sqrt(num)%1==0)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
