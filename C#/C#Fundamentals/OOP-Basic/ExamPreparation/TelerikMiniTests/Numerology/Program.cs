using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            Queue<int> numbers = new Queue<int>();
            var flipNumbers = new List<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            for (int i = 0; i < count; i++)
            {               
                numbers.Enqueue(i+1);
            }
            for (int i = 0; i < flipNumbers.Count; i++)
            {
                Console.WriteLine(string.Join(" ", numbers));
                numbers = RemoveNum(numbers, flipNumbers[i]);
            }
            //var result = RemoveNum(numbers, flipNumbers.Dequeue());
            //Console.Write(numbers.Peek());
            //Console.Write(string.Join(" ", numbers));
        }

        static Queue<int> RemoveNum(Queue<int>sequence, int num)
        {
            var currentNum = sequence.Dequeue();
            //Console.WriteLine(currentNum); 
            sequence.Enqueue(currentNum);
            if (currentNum != num)
            {                               
                RemoveNum(sequence, num);
            }
            
            return sequence;
        }
    }
}
