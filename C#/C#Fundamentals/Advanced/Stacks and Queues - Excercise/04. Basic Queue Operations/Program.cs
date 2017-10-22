using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var elementsCount = input[0];
            var elementsToPop = input[1];
            var elementToCheck = input[2];

            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>(elements);
            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
