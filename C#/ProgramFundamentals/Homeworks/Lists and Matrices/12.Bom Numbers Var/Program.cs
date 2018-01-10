using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int number = input[0];
        int lenght = input[1];

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == number)
            {
                int leftindex = Math.Max(i - lenght, 0);
                int rightindex = Math.Min(i + lenght, numbers.Count - 1);

                numbers.RemoveRange(i, rightindex - i);
                numbers.RemoveAt(i);
                numbers.RemoveRange(leftindex, i - leftindex);
                i = 0;
            }
        }
        Console.WriteLine(string.Join("", numbers.Sum()));
    }
}