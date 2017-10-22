using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace _02.Nature_s_Prophet
{
    class Program
    {
        static void Main(string[] args)
        {

            var matrixSize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var garden = new int [matrixSize[0], matrixSize[1]];
            var posN = new List<int>();
            var posM = new List<int>();

            while (true)
            {
                var flowers = Console.ReadLine();
                if (flowers == "Bloom Bloom Plow")
                {
                    break;
                }
                var flowersPoss = flowers.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                posN.Add(flowersPoss[0]);
                posM.Add(flowersPoss[1]);
                
            }
            BloomGarden(garden, posN,posM);
            PrintGarden(garden);
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

        static void PrintGarden(int[,]garden)
        {
            var Output = new StringBuilder();

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Output.Append(garden[row, col] + " ");
                }

                Output.Append("\n");
            }

            Console.Write(Output);
        }
        static void BloomGarden(int[,] garden, List<int> posN, List<int> posM)
        {

            for (int i = 0; i < posM.Count; i++)
            {
                garden[posN[i], posM[i]] -= 1;
            }
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                foreach (var m in posM)
                {
                    garden[i, m] += 1;
                }
                
            }
            for (int j = 0; j < garden.GetLength(1); j++)
            {
                foreach (var n in posN)
                {
                  garden[n, j] += 1;  
                }
                
            }


            //for (int i = 0; i < garden.GetLength(0); i++)
            //{
            //    for (int j = 0; j < garden.GetLength(1); j++)
            //    {
            //        if (i == n||j==m)
            //        {
            //            garden[i, j] += 1;
            //        }
            //    }

            //}
        }
    }
}
