using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {

            
            char[] separators = { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };

            string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<string> uppercase = new List<string>();
            List<string> lowercase = new List<string>();
            List<string> middlecase = new List<string>();


            foreach (var word in words)
            {
                if (TypeOfWord(word) == WordType.uppercase)
                {
                    uppercase.Add(word);
                }else if(TypeOfWord(word) == WordType.lowercase)
                {
                    lowercase.Add(word);
                }
                else
                {
                    middlecase.Add(word);
                }
            }
            Console.Write("Lower-case: ");
            Console.WriteLine(string.Join(", ",lowercase));
            Console.Write("Mixed-case: ");
            Console.WriteLine(string.Join(", ", middlecase));
            Console.Write("Upper-case: ");
            Console.WriteLine(string.Join(", ", uppercase));

        }
        enum WordType { uppercase, lowercase, middlecase };
        static WordType TypeOfWord(string word)
        {

            int countUpper = 0;
            int countLower = 0;

            foreach (var letter in word)
            {
                if (char.IsLower(letter))
                {
                    countLower++;
                }
                if (char.IsUpper(letter))
                {
                    countUpper++;
                }
            }
                if (countUpper == word.Length)
                {
                    return WordType.uppercase;
                }
                else if (countLower == word.Length)
                {
                    return WordType.lowercase;
                }
                else
                {
                    return WordType.middlecase;
                }
            
        }
    }
}
