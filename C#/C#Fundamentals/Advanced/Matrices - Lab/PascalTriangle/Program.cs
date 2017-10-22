using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

            var number = int.Parse(Console.ReadLine());
            var matrix = new int[number, number];

            for (int i = 1; i < number; i++)
            {
                for (int j = 1; j < number; j++)
                {
                    if (i == 0)
                    {
                        matrix[i, j] = 1;                       
                    }
                    else if(j==0&&i==0)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i-1, j-1] + matrix[i-1, j];
                    }
                }
            }
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    //if (matrix[i, j]!=0)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    
                }
                Console.WriteLine();
            }


        }
    }
}
