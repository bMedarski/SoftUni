using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {

            var nums = new Dictionary<string, int>();

            string[] words = Console.ReadLine().Split(' ').ToArray();
            var result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (nums.ContainsKey(words[i].ToLower()))
                {
                    nums[words[i].ToLower()]++;
                }
                else
                {
                    nums[words[i].ToLower()] = 1;
                }
            }
            foreach (var item in nums)
            {
                if (item.Value%2!=0)
                {
                    result.Add(item.Key);
                }
            }
            Console.WriteLine(string.Join(", ",result));
            
        }
    }
}
