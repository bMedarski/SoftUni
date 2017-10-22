using System;
using System.Collections;
using System.Collections.Generic;
public class Stack<T>:IEnumerable<T>
{

	private List<T> myCollection;

	public Stack(List<T> myCollection)
	{
		this.myCollection = new List<T>(myCollection);
	}

	public T Pop()
	{
		if (this.myCollection.Count==0)
		{
			throw new ArgumentException("No elements");
		}
		T element = this.myCollection[this.myCollection.Count - 1];
		this.myCollection.RemoveAt(this.myCollection.Count-1);
		return element;
	}

	public void Push(T item)
	{
		this.myCollection.Add(item);
	}

	public void Print()
	{
		for (int i = this.myCollection.Count-1; i >= 0; i--)
		{
			Console.WriteLine(this.myCollection[i]);			
		}
	}
	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < this.myCollection.Count; i++)
		{
			yield return this.myCollection[i];

		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}

