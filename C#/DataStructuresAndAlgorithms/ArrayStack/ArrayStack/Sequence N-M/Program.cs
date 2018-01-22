using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_N_M
{
	class Program
	{
		static void Main()		//NOT FINISHED
		{
			var inputArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var n = inputArgs[0];
			var m = inputArgs[1];
			var steps = new List<int>();
			var current = n;

			steps.Add(n);
			if (n > m)
			{
				Console.WriteLine("(no solution)");
			}
			else
			{
				while (current < m)
				{
					if (n*2+current<m)
					{
						current += n * 2;
						steps.Add(current);
					}else if (n + 2 + current < m)
					{
						current += n + 2;
						steps.Add(current);
					}else
					{
						current += n + 1;
						steps.Add(current);
					}
				}
				steps.Add(m);
				Console.WriteLine(string.Join(" -> ",steps));
			}

			
		}
	}
}
