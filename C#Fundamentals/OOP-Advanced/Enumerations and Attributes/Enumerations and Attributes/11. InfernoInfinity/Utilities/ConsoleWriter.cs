using System;

public class ConsoleWriter:IWriter
{
	public void Writer(string msg)
	{
		Console.WriteLine(msg);
	}
}

