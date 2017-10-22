using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Melrah_Shake
{
    class Program
    {
        static void Main()
        {

            var text = Console.ReadLine();
            var pattern = Console.ReadLine();
           
            while (true)
            {
                int lastindex = text.LastIndexOf(pattern);
                int firstindex = text.IndexOf(pattern);
                if (firstindex != -1 && lastindex != -1 && firstindex != lastindex
                    && pattern.Length > 0)
                {
                    text = ShakeIt(text, pattern);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
                //Console.WriteLine(pattern.Length / 2);
                pattern = pattern.Remove((pattern.Length / 2), 1);
                //Console.WriteLine(pattern);
            }

            Console.WriteLine(text);
        }

        static string ShakeIt(string text,string pattern)
        {
            var length = pattern.Length;
            text = text.Remove(text.IndexOf(pattern), length);
            text = text.Remove(text.LastIndexOf(pattern), length);           
            return text;
        }
    }
}
