using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(' ');
            var step = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(input);

            while (queue.Count>1)
            {
                for (int i = 0; i < step-1; i++)
                {
                    string item = queue.Dequeue();
                    queue.Enqueue(item);
                }
                Console.WriteLine("Removed {0}",queue.Dequeue());
            }
            Console.WriteLine("Last is {0}", queue.Dequeue());

        }
    }
}
