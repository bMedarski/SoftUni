using System;
using System.Collections.Generic;

public class AddRemoveCollection:AddCollection, IAddRemoveCollection
{
	public string Remove()
	{
		var listSize = base.list.Count;
		var itemToRemove = base.list[listSize-1];
		base.list.RemoveAt(listSize - 1);

		return itemToRemove;
	}
}

