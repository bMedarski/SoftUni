using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            var countCompounds = int.Parse(Console.ReadLine());

            var compound = new SortedSet<string>();

            for (int i = 0; i < countCompounds; i++)
            {
                var comp = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < comp.Length; j++)
                {
                    compound.Add(comp[j]);
                }
            }

            Console.WriteLine(string.Join(" ", compound));
        }
    }
}
