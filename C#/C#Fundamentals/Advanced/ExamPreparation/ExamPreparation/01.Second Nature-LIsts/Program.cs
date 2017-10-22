using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Second_Nature_LIsts
{
    class Program
    {
        static void Main(string[] args)
        {

            var flowers = new List<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var waterBuckets = new List<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var secondNature = new List<int>();
            int remainder = 0;


            while (waterBuckets.Count > 0 && flowers.Count > 0)
            {
                //Console.WriteLine($"Cikul:{count}----Flower-{flowers[0]}---Water{waterBuckets[waterBuckets.Count - 1]}");
                if (flowers[0] == waterBuckets[waterBuckets.Count - 1])
                {
                    secondNature.Add(flowers[0]);
                    flowers.RemoveAt(0);
                    waterBuckets.RemoveAt(waterBuckets.Count - 1);
                }
                else if (flowers[0] > waterBuckets[waterBuckets.Count - 1])
                {

                    flowers[0] -= waterBuckets[waterBuckets.Count - 1];
                    waterBuckets.RemoveAt(waterBuckets.Count - 1);
                }
                else if (waterBuckets[waterBuckets.Count - 1] > flowers[0])
                {
                    remainder = waterBuckets[waterBuckets.Count - 1] - flowers[0];
                    waterBuckets.RemoveAt(waterBuckets.Count - 1);
                    flowers.RemoveAt(0);

                    if (waterBuckets.Any())
                    {
                        waterBuckets[waterBuckets.Count - 1] += remainder;
                    }
                    else
                    {
                        waterBuckets.Add(remainder);
                    }
                    
                }

            }
            waterBuckets.Reverse();
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