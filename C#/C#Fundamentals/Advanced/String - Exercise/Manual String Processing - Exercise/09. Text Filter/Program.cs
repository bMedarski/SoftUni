using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Text_Filter
{
    class Program
    {
        static void Main()
        {

            var splitWord = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var text = Console.ReadLine();
            var result = text;
            foreach (var word in splitWord)
            {
                
                var pattern = new string('*',word.Length);
                result = result.Replace(word, pattern);
                
            }
            Console.WriteLine(result);
        }
    }
}
