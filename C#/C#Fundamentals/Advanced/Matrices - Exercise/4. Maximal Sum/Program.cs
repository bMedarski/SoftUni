using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _4.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();

            long[,] matrix = new long[input[0], input[1]];

            for (long i = 0; i < input[0]; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(long.Parse).ToArray();
                for (long j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            long count = 0;
            long maxCount = 0;
            long maxCellI = 0;
            long maxCellJ = 0;
            for (long i = 2; i < input[0]; i++)
            {
                for (long j = 2; j < input[1]; j++)
                {
                    count = matrix[i, j] + 
                        matrix[i - 1, j] + matrix[i - 2, j] + 
                        matrix[i, j - 1] + matrix[i, j - 2] + 
                        matrix[i - 1, j - 1] + matrix[i - 2, j - 2] + 
                        matrix[i - 1, j - 2] + matrix[i - 2, j - 1];
                    if (count>maxCount)
                    {
                        maxCount = count;
                        maxCellI = i;
                        maxCellJ = j;
                    }
                }             
            }
                Console.WriteLine($"Sum = {maxCount}");
                Console.Write($"{matrix[maxCellI - 2, maxCellJ - 2]} ");
                Console.Write($"{matrix[maxCellI - 2, maxCellJ - 1]} ");
                Console.Write($"{matrix[maxCellI - 2, maxCellJ - 0]}");
                Console.WriteLine();
                Console.Write($"{matrix[maxCellI - 1, maxCellJ - 2]} ");
                Console.Write($"{matrix[maxCellI - 1, maxCellJ - 1]} ");
                Console.Write($"{matrix[maxCellI - 1, maxCellJ - 0]}");
                Console.WriteLine();
                Console.Write($"{matrix[maxCellI - 0, maxCellJ - 2]} ");
                Console.Write($"{matrix[maxCellI - 0, maxCellJ - 1]} ");
                Console.Write($"{matrix[maxCellI - 0, maxCellJ - 0]}");
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
