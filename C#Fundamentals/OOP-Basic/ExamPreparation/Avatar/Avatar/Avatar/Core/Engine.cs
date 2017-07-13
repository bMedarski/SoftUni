using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
	private NationsBuilder nationsBuilder;

	public Engine()
	{
		this.nationsBuilder = new NationsBuilder();
	}

	public void Start()
	{
		while (true)
		{
			var input = Console.ReadLine().Split(' ').ToList();
			if (input[0] == Constants.END_OF_PROGRAM)
			{
				Execute(input);
				break;
			}

			Execute(input);
		}
	}

	public void Execute(List<string> inputArgs)
	{
		string command = inputArgs[0];
		inputArgs.RemoveAt(0);
		switch (command)
		{
			case "Bender":
				nationsBuilder.AssignBender(inputArgs);
				break;
			case "Monument":
				nationsBuilder.AssignMonument(inputArgs);
				break;
			case "Status":
				Console.WriteLine(nationsBuilder.GetStatus(inputArgs[0]));
				break;
			case "War":
				nationsBuilder.IssueWar(inputArgs[0]);
				break;
			case "Quit":
				Console.WriteLine(nationsBuilder.GetWarsRecord());
				break;
		}
	}
}

