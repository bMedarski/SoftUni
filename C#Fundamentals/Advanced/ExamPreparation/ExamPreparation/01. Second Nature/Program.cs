using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Second_Nature
{
    class Program
    {
        static void Main()
        {

            var flowers = new Queue<long>(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));              

            var waterBuckets = new Stack<long>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)); 
            var secondNature = new List<long>();
            long remainder = 0;
            long sumWater = 0;
                    
            while (flowers.Count > 0 && waterBuckets.Count>0)
            {
                if (flowers.Peek()== waterBuckets.Peek())
                {
                    secondNature.Add(flowers.Peek());
                    flowers.Dequeue();
                    waterBuckets.Pop();
                }
                else if (waterBuckets.Peek()> flowers.Peek())
                {
                    remainder = waterBuckets.Peek() - flowers.Peek();
                    flowers.Dequeue();

                    waterBuckets.Pop();
                    
                    if (waterBuckets.Count == 0)
                    {
                        break;
                    }
                    var currentBucket = waterBuckets.Peek();
                    waterBuckets.Pop();
                    waterBuckets.Push(currentBucket+ remainder);
                }
                else if (flowers.Peek()> waterBuckets.Peek())
                {
                    do
                    {
                        var lastBucket = waterBuckets.Pop();
                        sumWater = lastBucket + waterBuckets.Peek();

                    } while (flowers.Peek()>=sumWater);

                    flowers.Dequeue();
                    waterBuckets.Pop();
                }
            }
            if (flowers.Count > waterBuckets.Count)
            {
                Console.WriteLine(string.Join(" ", flowers));
            }
            else
            {
                Console.WriteLine(string.Join(" ", waterBuckets));
            }
            if (secondNature.Count > 0)
            {
                Console.WriteLine(string.Join(" ", secondNature));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
