using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = Console.ReadLine().Split().ToArray();

            string firstWord = words[0];
            string secondWord = words[1];

            long sum = getSum(firstWord,secondWord);
            Console.WriteLine(sum);
        }

        private static long getSum(string firstWord, string secondWord)
        {
            long sum = 0;
            int length = 0;
           
            if (firstWord.Length>=secondWord.Length)
            {
                length = secondWord.Length;
                for (int i = 0; i < length; i++)
                {
                    sum += (int)firstWord[i] * (int)secondWord[i];
                }
                for (int i = length; i < firstWord.Length; i++)
                {
                    sum += (int)firstWord[i];
                }
                
            }
            else
            {
                length = firstWord.Length;
                for (int i = 0; i < length; i++)
                {
                    sum += (int)firstWord[i] * (int)secondWord[i];
                }
                for (int i = length; i < secondWord.Length; i++)
                {
                    sum += (int)secondWord[i];
                }
            }
           

            return sum;
        }
    }
}
