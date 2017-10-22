using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {

           
            var padawans = new Queue<string>();
            var knights = new Queue<string>();           
            var masters = new Queue<string>();
            

            var linesOfInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesOfInput; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var item in input)
                {
                    var type = item[0];

                     if (type == 'p')
                    {
                        padawans.Enqueue(item);
                    }
                    else if (type == 'k')
                    {
                        knights.Enqueue(item);
                    }
                    else if (type == 'm')
                    {
                        masters.Enqueue(item);
                    }
                }
            }
                Console.WriteLine(
                    $"{string.Join(" ", masters)} {string.Join(" ", knights)} {string.Join(" ", padawans)}");
        }
    }
}
