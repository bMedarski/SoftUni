using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.BuildMatrixLetters
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];
            matrix[0, 0] = 'A';
            int count = 0;
                       
            for (int i =0; i<rows; i++)
            {

                for (int j = 0; j <cols; j++)
                {
                    matrix[i, j]= (char)('A'+count);
                    Console.Write("{0} ", matrix[i, j]);
                    count++;
                }
                Console.WriteLine();

            }



        }
    }
}
