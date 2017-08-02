using System;
using System.Collections.Generic;

public class AddCollection: IAddCollection
{
	protected List<string> list;

	public AddCollection()
	{
		this.list = new List<string>();
	}
	public int Add(string item)
	{
		this.list.Add(item);
		return this.list.Count - 1;
	}
}

