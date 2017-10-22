using System.Collections.Generic;

public abstract class Factory
{
	public abstract Worker Create(List<string> args);
}

