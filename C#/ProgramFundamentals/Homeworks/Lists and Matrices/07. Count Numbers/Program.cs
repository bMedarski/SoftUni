using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Count_Numbers
{
    class Program           //NOT WORKING CORRECTLY
    {
        static void Main(string[] args)
        {

            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            nums.Sort();
            int currNum = nums[0];
            int count = 1;
            if (nums.Count == 1)
            {
                Console.WriteLine("{0} -> {1}", currNum, count);
            }
            else
            {
                for (int i = 0; i < nums.Count-1; i++)
                {
                    if (nums[i+1] == currNum)
                    {
                            count++;
                    }
                    else
                    {
                        Console.WriteLine("{0} -> {1}", currNum, count);
                        count = 1;
                        currNum = nums[i];
                       
                    }
                    if (i == nums.Count - 2 && nums[nums.Count - 1] == nums[nums.Count - 2])
                    {

                        Console.WriteLine("{0} -> {1}", currNum, count);
                    }
                }
            }


        }
    }
}

