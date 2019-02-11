using System;

public class LinkedStack<T>
{
	private Node<T> firstNode;
	public int Count { get; private set; }

	public void Push(T element)
	{
		var newFirst = new Node<T>(element, this.firstNode);
		this.firstNode = newFirst;
		this.Count++;
	}

	public T Pop()
	{
		if (this.Count==0)
		{
			throw new InvalidOperationException();
		}
		var element = this.firstNode;
		Console.WriteLine(element.Value);
		var secondElement = element.NextNode;
		this.firstNode = secondElement;
		this.Count--;
		return element.Value;
	}

	public T[] ToArray()
	{
		var arr = new T[this.Count];
		var currentNode = this.firstNode;

		for (int i = 0; i < this.Count; i++)
		{
			arr[i] = currentNode.Value;
			currentNode = currentNode.NextNode;
		}
		return arr;
	}
}
