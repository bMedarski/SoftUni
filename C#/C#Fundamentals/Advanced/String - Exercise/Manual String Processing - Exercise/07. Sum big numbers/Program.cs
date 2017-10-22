using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sum_big_numbers
{
    class Program           /// Not finished
    {
        static void Main(string[] args)
        {
            var numOne = Console.ReadLine();
            var numTwo = Console.ReadLine();

            numOne = ReverseNum(numOne);
            numTwo = ReverseNum(numTwo);
            var sum = 0;
            var oneInMind = false;

            for (int i = 0; i < Math.Max(numOne.Length,numTwo.Length); i++)
            {
                
            }
        }

        static string ReverseNum(string num)
        {
            var reversed = "";
            var sb = new StringBuilder();
            for (int i = num.Length; i > 0; i--)
            {
                sb.Append(num[i - 1]);
            }
            reversed = sb.ToString();
            return reversed;
        }
    }
}
