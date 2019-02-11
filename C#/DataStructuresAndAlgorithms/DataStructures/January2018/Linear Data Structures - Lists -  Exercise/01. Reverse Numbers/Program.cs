using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			var arr = Console.ReadLine().Split();
			var stack = new Stack<string>(arr);

			Console.WriteLine(string.Join(" ",stack));
		}
	}
}
 