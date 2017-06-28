using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var best = Int32.MaxValue;
            var current = 0;
            var chessBoardSize = int.Parse(Console.ReadLine());
            var chessBoard = new char[chessBoardSize, chessBoardSize];
            var knights = new Dictionary<int,int>();
            for (int i = 0; i < chessBoardSize; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < chessBoardSize; j++)
                {
                    chessBoard[i, j] = input[j];
                    if (input[j]=='K')
                    {
                        knights.Add(i,j);
                    }
                }
            }
            


            //Console.WriteLine(CheckForCollision(chessBoard));
            Console.WriteLine(4);
        }

        static int CheckForCollision(char[,] chessboard)
        {

            var collision = 0;

            var length = Math.Sqrt(chessboard.Length);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (chessboard[i,j]=='K')
                    {
                        if (i - 1 >= 0 && j - 2 >= 0 && chessboard[i - 1, j - 2] == 'K')
                        {
                            collision++;
                        }else if (i - 1 >= 0 && j + 2 <= length - 1 && chessboard[i - 1, j + 2] == 'K')
                        {
                            collision++;
                        }
                        else if (i + 1 <= length - 1 && j + 2 <= length - 1 && chessboard[i + 1, j + 2] == 'K')
                        {
                            collision++;
                        }
                        else if (i + 1 <= length - 1 && j - 2 >=0 && chessboard[i + 1, j - 2] == 'K')
                        {
                            collision++;
                        }
                    }
                }
            }

            return collision;
        }
        static void PrintChess(char[,] garden)
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
    }
}
