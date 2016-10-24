using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = Console.ReadLine().Split(new char[] {' ',',','?','!','.','"', },StringSplitOptions.RemoveEmptyEntries);
            List<string> palidromes = new List<string>();
            
           
            foreach (var word in words)
            {
                if (isPalidrome(word))
                {
                    palidromes.Add(word);
                }
            }
            Console.WriteLine(string.Join(", ", palidromes.Distinct().OrderBy(x => x)));
        }

        private static bool isPalidrome(string word)
        {
            StringBuilder output = new StringBuilder();

            for (int i = word.Length - 1; i >= 0; i--)
            {
                output.Append(word[i]);
            }
            if (output.ToString()==word)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
