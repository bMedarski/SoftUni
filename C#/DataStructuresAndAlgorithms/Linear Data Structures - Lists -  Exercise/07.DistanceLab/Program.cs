using System;
using System.Collections.Generic;

namespace MyNamespace
{
	public class Cell
	{

		public Cell(int row, int col)
		{
			this.Row = row;
			this.Col = col;
		}

		public int Row { get; set; }

		public int Col { get; set; }

	}

	public class Program
	{
		private static Cell startingPosition;
		private static Stack<Cell> cells = new Stack<Cell>();

		static void Main()
		{
			int size = int.Parse(Console.ReadLine());

			int[,] matrix = ReadMatrix(size);
			string[,] finalMatrix = new String[size, size];
			cells.Push(startingPosition);
			while (cells.Count > 0)
			{
				Cell currentCell = cells.Pop();
				AddCells(currentCell, matrix);
			}
			//Print(matrix);
			FillFinalMatrix(matrix, finalMatrix);
			Console.WriteLine();
			Print(finalMatrix);
			//Print(matrix);
		}

		private static void FillFinalMatrix(int[,] matrix, string[,] finalMatrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(0); j++)
				{
					if (matrix[i, j] == 0)
					{
						finalMatrix[i, j] = "u";
					}
					else if (matrix[i, j] == -1)
					{
						finalMatrix[i, j] = "x";
					}
					else if (i == startingPosition.Row && j == startingPosition.Col)
					{
						finalMatrix[i, j] = "*";
					}
					else if (matrix[i, j] > 0)
					{
						finalMatrix[i, j] = matrix[i, j].ToString();
					}

					if (i == startingPosition.Row && j == startingPosition.Col)
					{
						finalMatrix[i, j] = "*";
					}
				}
			}

		}
		private static bool isBlockVisitedStart(Cell cell, int[,] matrix)
		{

			if (matrix[cell.Row, cell.Col] == matrix[startingPosition.Row, startingPosition.Col])
			{
				return false;
			}
			else if (matrix[cell.Row, cell.Col] == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		private static void AddCells(Cell cell, int[,] matrix)
		{



			if (cell.Row + 1 < matrix.GetLength(0))
			{
				Cell newCell = new Cell(cell.Row + 1, cell.Col);
				if (!isBlockVisitedStart(newCell, matrix))
				{
					cells.Push(newCell);
					matrix[cell.Row + 1, cell.Col] = matrix[cell.Row, cell.Col] + 1;
				}
			}
			if (cell.Row - 1 >= 0)
			{
				Cell newCell = new Cell(cell.Row - 1, cell.Col);
				if (!isBlockVisitedStart(newCell, matrix))
				{
					cells.Push(newCell);
					matrix[cell.Row - 1, cell.Col] = matrix[cell.Row, cell.Col] + 1;
				
				}
			}
			if (cell.Col + 1 < matrix.GetLength(0))
			{
				Cell newCell = new Cell(cell.Row, cell.Col + 1);
				if (!isBlockVisitedStart(newCell, matrix))
				{
					cells.Push(newCell);
					matrix[cell.Row, cell.Col + 1] = matrix[cell.Row, cell.Col] + 1;
				
				}
			}
			if (cell.Col - 1 >= 0)
			{
				Cell newCell = new Cell(cell.Row, cell.Col - 1);
				if (!isBlockVisitedStart(newCell, matrix))
				{
					cells.Push(newCell);
					matrix[cell.Row, cell.Col - 1] = matrix[cell.Row, cell.Col] + 1;
				
				}
			}
			if (matrix[cell.Row, cell.Col] == matrix[startingPosition.Row, startingPosition.Col])
			{
				matrix[startingPosition.Row, startingPosition.Col] = -2;
			}

		}
		private static void Print(string[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(0); j++)
				{
					Console.Write(matrix[i, j]);
				}
				Console.WriteLine();
			}
		}
		private static void Print(int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(0); j++)
				{
					Console.Write(matrix[i, j]);
				}
				Console.WriteLine();
			}
		}
		private static int[,] ReadMatrix(int size)
		{
			int[,] matrix = new int[size, size];

			for (int row = 0; row < size; row++)
			{
				char[] line = Console.ReadLine().ToCharArray();

				for (int col = 0; col < size; col++)
				{
					if (line[col] == '*')
					{
						startingPosition = new Cell(row, col);
						matrix[row, col] = 0;
					}
					else if (line[col] == '0')
					{
						matrix[row, col] = 0;
					}
					else if (line[col] == 'x')
					{
						matrix[row, col] = -1;
					}
				}
			}
			return matrix;
		}
	}



}
