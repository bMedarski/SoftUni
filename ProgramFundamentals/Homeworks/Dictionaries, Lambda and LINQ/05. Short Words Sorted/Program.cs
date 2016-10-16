using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] separators = { ',', '.', '!', '/', '\\', '\'', '"', '[', ']', '(', ')', '*', '?', ':', ';', ' '};
            string[] words = Console.ReadLine().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length < 5).OrderBy(x => x).Distinct().ToArray();
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
