using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LetersChgNums
{
    class Program
    {
        private static string alphabet = ".abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {

            var words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var sum = 0d;
            foreach (var word in words)
            {
                sum += ConvertWord(word);
            }
            Console.WriteLine($"{sum:F2}");
        }

        static double ConvertWord(string word)
        {

            var length = word.Length;
            var firstLetter = word[0];
            var secondLetter = word[word.Length - 1];
            var number = double.Parse(word.Substring(1, word.Length - 2));
            var sum = number;
            if (Char.IsLower(firstLetter))
            {
                var amplifier = alphabet.IndexOf(firstLetter);
                sum *= amplifier;
            }
            else
            {
                firstLetter = char.Parse(firstLetter.ToString().ToLower());
                var divider = alphabet.IndexOf(firstLetter);
                sum = sum / divider;
            }

            if (Char.IsLower(secondLetter))
            {
                var subiraemo = alphabet.IndexOf(secondLetter);
                sum += subiraemo;
            }
            else
            {
                secondLetter = char.Parse(secondLetter.ToString().ToLower());
                var delimo = alphabet.IndexOf(secondLetter);
                sum = sum - delimo;
            }

            return sum;
        }
    }
}
