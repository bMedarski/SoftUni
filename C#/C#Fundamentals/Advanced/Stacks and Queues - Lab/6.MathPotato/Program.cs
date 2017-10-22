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
            var counter = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < step - 1; i++)
                {
                    
                    string item = queue.Dequeue();
                    queue.Enqueue(item);
                }
                if (!IsPrime(counter))
                    {
                        Console.WriteLine("Removed {0}", queue.Dequeue());
                        counter++;
                    }
                else
                {
                    Console.WriteLine("Prime {0}", queue.Peek());
                    counter++;
                }
                
            }
            Console.WriteLine("Last is {0}", queue.Dequeue());

        }

        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
}
