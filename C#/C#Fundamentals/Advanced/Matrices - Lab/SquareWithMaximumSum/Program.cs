using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
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
            var indexI = 0;
            var indexJ = 0;
            for (int i = 0; i < input[0]-1; i++)
            {               
                for (int j = 0; j < input[1]-1; j++)
                {
                    var currentSum = matrix[i, j] + matrix[i+1, j] + matrix[i, j+1] + matrix[i+1, j+1];
                    if (currentSum>sum)
                    {
                        sum = currentSum;
                        indexI = i;
                        indexJ = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[indexI,indexJ]} {matrix[indexI, indexJ+1]}");
            Console.WriteLine($"{matrix[indexI+1, indexJ]} {matrix[indexI + 1, indexJ+1]}");
            Console.WriteLine($"{sum}");
        }
    }
}
