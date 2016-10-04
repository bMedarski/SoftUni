using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Rotate_a_Matrix
{
    class Program       //NOT FINISHED
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];
            char[,] reverseMatrix = new char[cols, rows];

            for (int i = 0; i<rows; i++)
            {
                for (int j = 0; j<cols; j++)
                {
                    matrix[i, j] = char.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i<cols; i++)
            {
                for (int j=0; j<rows; j++)
                {
                    reverseMatrix[i, j] = matrix[cols-i-1,rows-j-1];
                }
            }

        }
    }
}
