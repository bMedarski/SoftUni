using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RemoveOddOccurs
{
    class Program
    {
        static void Main(string[] args)
        {
			var list = Console.ReadLine().Split().Select(int.Parse).ToList();
			var numbers = new List<int>();
			
	        for (int i = 0; i < list.Count; i++)
	        {
		        var currentNumber = list[i];
		        var counter = 0;
		        for (int j = 0; j < list.Count; j++)
		        {

			        if (i!=j&&list[i]==list[j])
			        {
				        counter++;
			        }
		        }
		        if (counter%2!=0)
		        {
			        numbers.Add(list[i]);
		        }
	        }
			Console.WriteLine(string.Join(" ",numbers));
		}
    }
}
