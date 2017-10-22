using System.Collections;
using System.Collections.Generic;

public class Lake:IEnumerable<int>
{
	private List<int> colection;

	public Lake(List<int> colection)
	{
		this.colection = new List<int>(colection);
	}


	public IEnumerator<int> GetEnumerator()
	{
		var tempList = new List<int>();
		var odd = new List<int>();
		for (int i = 0; i < this.colection.Count; i++)
		{
			if (i % 2 == 0)
			{
				tempList.Add(this.colection[i]);
			}
			else
			{
				odd.Add(this.colection[i]);
			}
		}
		odd.Reverse();
		tempList.AddRange(odd);
		foreach (var i in tempList)
		{
			yield return i;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}

