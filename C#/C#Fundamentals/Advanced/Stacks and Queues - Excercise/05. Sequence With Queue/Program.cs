using System;
using System.Collections.Generic;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<long>();
            long baseNumber = long.Parse(Console.ReadLine());
            long currentNumber = 0;
            long counter = 1;
            queue.Enqueue(baseNumber);
            while (counter<=50)
            {
                currentNumber = queue.Peek();
                queue.Enqueue(currentNumber+1);
                queue.Enqueue(2*currentNumber+1);
                queue.Enqueue(currentNumber+2);
                Console.Write("{0} ",queue.Dequeue());
                counter++;
            }           
        }    
    }
}
