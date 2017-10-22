using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Swapping
{
    class Program
    {
        static void Main()
        {

            var number = int.Parse(Console.ReadLine());
            var flips = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var result = new List<int>();
            for (int i = 0; i < number; i++)
            {
                result.Add(i+1);
            }
            foreach (var flip in flips)
            {
                result = FlipNumbers(flip, result);
            }
            

            Console.WriteLine(string.Join(" ",result));
        }

        static List<int> FlipNumbers(int index,List<int> numbers)
        {
            var result = new List<int>();

            var indexOfNum = numbers.IndexOf(index);
            var leftNums = numbers.GetRange(0, numbers.Count - (numbers.Count - indexOfNum ));
            //Console.WriteLine(string.Join(" ", leftNums));
            var rightNums = numbers.GetRange(indexOfNum+1, numbers.Count-indexOfNum-1);
            //Console.WriteLine(string.Join(" ", rightNums));

            result.AddRange(rightNums);
            result.Add(index);
            result.AddRange(leftNums);
            return result;
        }
    }
}
