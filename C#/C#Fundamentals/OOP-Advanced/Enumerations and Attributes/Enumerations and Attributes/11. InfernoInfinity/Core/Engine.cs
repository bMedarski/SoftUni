using System.Linq;

public class Engine
{
	private IReader reader;
	private IWriter writer;
	private ICommandFactory commandFactory;

	public Engine(IReader reader, IWriter writer, ICommandFactory commandFactory)
	{
		this.reader = reader;
		this.writer = writer;
		this.commandFactory = commandFactory;
	}

	public void Start()
	{
		while (true)
		{
			var input = this.reader.Reader().Split(';').ToList();
			if (input[0]=="END")
			{
				break;
			}
			string command = input[0];
			input.RemoveAt(0);
			ICommand currentCommand = this.commandFactory.GetCommand(command,input);
			currentCommand.Execute();	
		}
	}
}

