using System;
using System.Linq;

namespace _03._Longest_Subsequence
{
    class Program
    {
        static void Main(string[] args)
		{
			var list = Console.ReadLine().Split().Select(int.Parse).ToList();

			var bestCount = 1;
			var bestNumber = list[0];
			var currentCount = 1;
			var currentNumber = list[0];

			for (int i = 1; i < list.Count; i++)
			{
				if (list[i] == list[i - 1])
				{
					currentCount++;
					if (currentCount > bestCount)
					{
						bestCount = currentCount;
						bestNumber = list[i];
					}
				}
				else
				{
					currentCount = 1;
				}
				//Console.WriteLine();
			}

			for (int i = 0; i < bestCount; i++)
			{
				Console.Write(bestNumber+" ");
			}
		}
    }
}
