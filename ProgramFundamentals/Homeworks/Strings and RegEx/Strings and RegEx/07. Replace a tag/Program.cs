using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.Replace_a_tag
{
    class Program
    {
        static void Main(string[] args) //  66/100
        {

            string text = Console.ReadLine();
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]!= ' ')
                {
                    str.Append(text[i]);
                }
            }
            //text = text.Replace("<a href=","[URL href=");            
            //text = text.Replace("\">", "\"]");            
            //text = text.Replace("</a>", "[/URL]");
            str.Replace("<a", "[URL ");
            str.Replace("\">", "\"]");
            str.Replace("</a>", "[/URL]");

            Console.WriteLine(str);

        }
    }
}
