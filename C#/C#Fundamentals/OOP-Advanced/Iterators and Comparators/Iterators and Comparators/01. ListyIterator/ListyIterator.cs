using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T>:IEnumerable<T>
{
	private IList<T> list;
	private int currentIndex;


	public ListyIterator(List<T> collection)
	{
		this.currentIndex = 0;
		this.list = new List<T>(collection);
	}

	public bool Move()
	{
		if (this.currentIndex + 1 >= this.list.Count)
		{
			return false;
		}

		this.currentIndex++;
		return true;
	}

	public bool HasNext()
	{
		if (this.currentIndex + 1 >= this.list.Count)
		{
			return false;
		}

		return true;
	}

	public void Yes()
	{
		Console.WriteLine(this.currentIndex);
	}
	public void Print()
	{
		if (this.list.Count == 0)
		{
			throw new ArgumentException("Invalid Operation!");
		}
		else
		{
			//Console.WriteLine(this.currentIndex);
			Console.WriteLine(this.list[this.currentIndex]);
		}
	}

	public void PrintAll()
	{
		if (this.list.Count == 0)
		{
			throw new ArgumentException("Invalid Operation!");
		}
		else
		{
			Console.WriteLine(string.Join(" ",this.list));
		}
	}
	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < this.list.Count; i++)
		{
			yield return this.list[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}

