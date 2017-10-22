using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            var matrix = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {                   
                    matrix[i, j] = alphabet[i].ToString() + alphabet[i+j].ToString() + alphabet[i].ToString();
                }
            }


            PrintMatrix(matrix);

        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
