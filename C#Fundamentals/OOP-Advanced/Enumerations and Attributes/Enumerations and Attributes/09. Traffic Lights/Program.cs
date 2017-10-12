using System;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{

		var input = Console.ReadLine().Split(' ').Select(n => (TrafficLight) Enum.Parse(typeof(TrafficLight), n)).ToList();

		var cycles = int.Parse(Console.ReadLine());

		for (int i = 0; i < cycles; i++)
		{
			for (int j = 0; j < input.Count; j++)
			{
				
					if ((int)input[j]==0)
					{
						input[j] = TrafficLight.Yellow;
					}
					else if ((int)input[j] == 1)
					{
					input[j] = TrafficLight.Red;
					}
					else if ((int)input[j] == 2)
					{
						input[j] = TrafficLight.Green;
					}
			}
			Console.WriteLine(string.Join(" ",input));
		}
	}
}


