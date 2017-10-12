class StartUp
{
	static void Main()
	{
		ICommandFactory commandFactory = new CommandFactory();
		IReader reader = new ConsoleReader();
		IWriter writer = new ConsoleWriter();

		Engine engine = new Engine(reader,writer,commandFactory);
		engine.Start();
	}
}

