using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStack
{
	class Program
	{
		static void Main()
		{
			var stack = new ArrayStack<int>(4);

			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			stack.Push(4);	
			stack.Push(5);
			stack.Print();
			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Count);
			stack.Push(1);
			stack.Push(2);
			stack.Print();
		}
	}
}
