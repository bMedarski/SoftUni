using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = File.ReadAllText("input/text.txt").ToLower();
            string words = File.ReadAllText("input/words.txt").ToLower();
            string[] word = words.Split().ToArray();
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var item in word)
            {
                wordCount[item] = 0;
            }
            string[] split = input.Split(new char[] {' ',',','\'','"','\\','/','`','!','?','(',')','-','.' }).ToArray();
            for (int i = 0; i < split.Length; i++)
            {
                if (wordCount.ContainsKey(split[i]))
                {
                    wordCount[split[i]]++;
                }
            }
            foreach (var item in wordCount.OrderByDescending(x=>x.Value))
            {
                string output = item.Key + " - " + item.Value + Environment.NewLine;
                File.AppendAllText("output/output.txt",output);
            }
        }
    }
}
