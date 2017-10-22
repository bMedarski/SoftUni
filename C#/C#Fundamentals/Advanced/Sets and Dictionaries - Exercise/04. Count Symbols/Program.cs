namespace _04.Count_Symbols
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var occurances = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (occurances.ContainsKey(input[i]))
                {
                    occurances[input[i]]++;
                }
                else
                {
                    occurances.Add(input[i], 1);
                }
            }

            foreach (var occur in occurances)
            {
                Console.WriteLine($"{occur.Key}: {occur.Value} time/s");
            }
        }
    }
}