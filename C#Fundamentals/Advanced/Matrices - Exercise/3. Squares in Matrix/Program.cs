using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[,] matrix = new string[input[0], input[1]];

            for (int i = 0; i < input[0]; i++)
            {           
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            var count = 0;
            for (int i = 1; i < input[0]; i++)
            {

                for (int j = 1; j < input[1]; j++)
                {
                    if (matrix[i,j]==matrix[i-1,j]&& matrix[i, j] == matrix[i,j-1]&& matrix[i, j] == matrix[i-1, j - 1])
                    {
                        count++;
                    }
                }
            }

            if (count==0)
            {
                Console.WriteLine("No 2 x 2 squares of equal cells exist.");
            }
            else
            {
                 Console.WriteLine(count);
            }
           

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
