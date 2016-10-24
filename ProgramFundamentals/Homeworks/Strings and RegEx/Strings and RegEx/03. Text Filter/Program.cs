using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(new char[] { ' ',','},StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();                    
            foreach (var item in banWords)
            {
                if (text.Contains(item))
                {
                    text = text.Replace(item, new string('*', item.Length));
                }
            }                          
            Console.WriteLine(text);
        }
    }
}
