using System;
using System.Linq;

public class Engine
{
	private bool isRunning = true;
	private DraftManager manager;
	public Engine()
	{
		this.manager = new DraftManager();
		this.Reader = new ConsoleReader();
		this.Writer = new ConsoleWriter();
	}

	public ConsoleReader Reader { get; set; }
	public ConsoleWriter Writer { get; set; }

	public void Start()
	{

		while (isRunning)
		{
			var commandAsString = this.Reader.ReadLine().Split(' ').ToList();
			string command = commandAsString[0];
			commandAsString.RemoveAt(0);

			try
			{
				switch (command)
				{
					case "RegisterHarvester":
						this.Writer.WriteLine(this.manager.RegisterHarvester(commandAsString));
						break;
					case "RegisterProvider":
						this.Writer.WriteLine(this.manager.RegisterProvider(commandAsString));
						break;
					case "Day":
						this.Writer.WriteLine(this.manager.Day());
						break;
					case "Mode":
						this.Writer.WriteLine(this.manager.Mode(commandAsString));
						break;
					case "Check":
						this.Writer.WriteLine(this.manager.Check(commandAsString));
						break;
					case "Shutdown":
						this.Writer.WriteLine(this.manager.ShutDown());
						isRunning = false;
						break;
				}
			}
			catch (ArgumentException e)
			{
				this.Writer.WriteLine(e.Message);
			}

		}

	}
}
