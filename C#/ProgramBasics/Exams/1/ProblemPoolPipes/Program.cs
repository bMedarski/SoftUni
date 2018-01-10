using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPoolPipes
{
    class Program
    {
        static void Main(string[] args)
        {

            int poolSize = int.Parse(Console.ReadLine());
            int firstPipe = int.Parse(Console.ReadLine());
            int secondPipe = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double currentSize = firstPipe * hours + secondPipe * hours;

            if (poolSize<currentSize)
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.",hours,currentSize-poolSize);
            }
            else
            {
                double part = currentSize / poolSize * 100;
                double first = firstPipe * hours / currentSize * 100;
                double second = secondPipe * hours / currentSize * 100;
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", Math.Floor(part),Math.Floor(first),Math.Floor(second));
            }

        }
    }
}
