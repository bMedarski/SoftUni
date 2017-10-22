using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        static void Main()
        {

            string text = Console.ReadLine();
            string pattern = @"\[[^\[\]\s\x00-\x1f]+<(\d+)REGEH(\d+)>[^\[\]\s\x00-\x1f]+\]";
            //string patternNumbers = @"<(\d+)REGEH(\d+)>";
            var listOfNumbers = new List<int>();
            var result = new StringBuilder();
            int currentIndex = 0;

            foreach (Match m in Regex.Matches(text, pattern))
            {
                //foreach (Match num in Regex.Matches(m.ToString(),patternNumbers))
                //{
                listOfNumbers.Add(int.Parse(m.Groups[1].Value));
                listOfNumbers.Add(int.Parse(m.Groups[2].Value));
                //}
            }
            //Console.WriteLine(text.Length);115
            foreach (int number in listOfNumbers)
            {
                currentIndex += number;

                if (currentIndex > text.Length)
                {
                    //Console.WriteLine(currentIndex);
                    //Console.WriteLine(text.Length);
                    currentIndex = currentIndex % text.Length;
                    currentIndex++;
                }
                //Console.WriteLine(currentIndex);
                var letter = text.Substring(currentIndex, 1);

                //Console.WriteLine(letter);
                result.Append(text.Substring(currentIndex, 1));
            }
            Console.WriteLine(result);
        }
    }
}