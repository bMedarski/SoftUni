using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {

            var linesCount = int.Parse(Console.ReadLine());
            var messages = new List<string>();
            var names = new List<string>();
            var text = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                text.Append(Console.ReadLine());
            }
            var namePattern = Console.ReadLine();
            var msgPattern = Console.ReadLine();
            var nameToMsg = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string patternName = $"{namePattern}(\\w+)";
            string patternMsg = $"{msgPattern}(\\w+)";
            var strText = text.ToString();


            foreach (Match m in Regex.Matches(strText, patternName))
            {
                names.Add(m.Groups[1].Value.Substring(0, namePattern.Length));
            }
            foreach (Match m in Regex.Matches(strText, patternMsg))
            {
                messages.Add(m.Groups[1].Value.Substring(0, msgPattern.Length));
            }


            Console.WriteLine(string.Join(" ,",names));
            Console.WriteLine(string.Join(" ,", messages));
        }
    }
}
