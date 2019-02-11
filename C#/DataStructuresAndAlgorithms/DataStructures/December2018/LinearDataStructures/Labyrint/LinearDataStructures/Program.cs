using System;

internal class Program
{
	static void Main(string[] args)
	{
		var size = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

		var matrix = new string[size,size];
		var rowStart = 0;
		var colStart = 0;


		for (int i = 0; i < size; i++)
		{
			var row = Console.ReadLine();
			for (int j = 0; j < size; j++)
			{
				matrix[i, j] = row[j].ToString();
				if (row[j].ToString() == "*")
				{
					rowStart = i;
					colStart = j;
				}
			}
		}

		var stillZeros = true;

		while (stillZeros)
		{
			stillZeros = false;

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					
				}
			}
		}

		Console.WriteLine();
	}
}

