using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {

            var words = Console.ReadLine().Split(new char[] { '\n', ',', ';', ':', '.', '!', '(', ')', '"', '-', '\\', '/', '[', ']', ' ', '?', '\r', '`', '_', '{', '}', '<', '>', '\'' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            var palindromes = new List<string>();
            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }
            palindromes.Sort();
            var unique = new HashSet<string>();
            foreach (var palindrome in palindromes)
            {
                unique.Add(palindrome);
            }
            Console.Write("[");
            Console.Write(string.Join(", ", unique));
            Console.WriteLine("]");
        }

        static bool IsPalindrome(string word)
        {
            var wordChar = word.ToCharArray();
            var lenght = word.Length;
            for (int i = 0; i < lenght / 2; i++)
            {
                if (word[i]!=word[lenght-i-1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
