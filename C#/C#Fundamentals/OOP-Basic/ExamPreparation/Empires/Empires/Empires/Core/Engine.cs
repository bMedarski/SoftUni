using System;
using System.Linq;

class Engine
{

	private GameManager manager;
	

	public Engine()
	{
		this.manager = new GameManager();
	}

	public void Start()
	{
		while (true)
		{
			string[] input = Console.ReadLine().Split(' ').ToArray();

			if (input[0]==Constants.END_GAME_INPUT)
			{
				break;
			}

			switch (input[0])
			{
				case "build":
					manager.Turn();
					manager.Build(input[1]);
					break;
				case "skip":
					manager.Turn();
					break;
				case "empire-status":
					
					Console.WriteLine(manager.Status());
					manager.Turn();
					break;
			}
		}
	}
}

