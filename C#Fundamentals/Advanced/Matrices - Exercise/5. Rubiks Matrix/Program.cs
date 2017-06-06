using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {


            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var counter = 1;
            var matrix = new int[input[0],input[1]];
            for (int i = 0; i < input[0]; i++)
            {
                for (int j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
            var commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            }


            PrintMatrix(matrix);
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
