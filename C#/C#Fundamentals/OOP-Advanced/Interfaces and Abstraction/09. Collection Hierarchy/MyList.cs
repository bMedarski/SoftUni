using System;
using System.Collections.Generic;

public class MyList:IMyList
{
	private List<string> list;

	string IAddRemoveCollection.Remove()
	{
		throw new NotImplementedException();
	}

	int IAddCollection.Add(string item)
	{
		throw new NotImplementedException();
	}

	public int Used { get { return this.list.Count; } }
}

