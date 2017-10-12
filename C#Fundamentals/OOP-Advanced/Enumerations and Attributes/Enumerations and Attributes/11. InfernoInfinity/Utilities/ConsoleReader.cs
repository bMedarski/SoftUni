using System;

public class ConsoleReader:IReader
{
	public string Reader()
	{
		var result = Console.ReadLine();
		return result;
	}
}