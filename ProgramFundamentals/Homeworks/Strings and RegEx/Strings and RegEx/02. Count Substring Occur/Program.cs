using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Count_Substring_Occur
{
    class Program
    {
        static void Main(string[] args)
        {

            string words = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();
            int count = 0;


            for (int i = 0; i < words.Length-word.Length+1; i++)
            {
                if (words.Substring(i,word.Length)==word)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            
        }
    }
}
