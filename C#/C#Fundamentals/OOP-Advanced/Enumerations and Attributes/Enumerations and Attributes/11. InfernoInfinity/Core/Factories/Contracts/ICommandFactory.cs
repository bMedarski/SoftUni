using System.Collections.Generic;

public interface ICommandFactory
{
	ICommand GetCommand(string command,IList<string> argsList);
}

