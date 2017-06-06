using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfAllElementsOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int i = 0; i < input[0]; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
                
            }
            var sum = 0;
            foreach (var i in matrix)
            {
                sum += i;
            }
            Console.WriteLine(input[0]);
            Console.WriteLine(input[1]);
            Console.WriteLine(sum);
        }
    }
}
