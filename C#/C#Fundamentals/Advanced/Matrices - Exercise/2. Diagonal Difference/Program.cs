using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int sumLeftDiagonal = 0;
            int sumRightDiagonal = 0;
            for (int i = 0; i < size; i++)
            {
              
                for (int j = 0; j < size; j++)
                {
                    if (i==j)
                    {
                        sumLeftDiagonal += matrix[i, j];
                    }
                    if (i+j==size-1)
                    {
                        sumRightDiagonal += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumRightDiagonal-sumLeftDiagonal));
            
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
