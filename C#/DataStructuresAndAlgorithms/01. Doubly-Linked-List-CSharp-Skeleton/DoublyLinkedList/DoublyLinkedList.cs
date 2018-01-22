using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
	public int Count { get; private set; }
	public Node<T> First { get; private set; }
	public Node<T> Last { get; private set; }

	public DoublyLinkedList()
	{
		this.First = null;
		this.Last = null;
	}
	public void AddFirst(T element)
	{
		var newElement = new Node<T>(element);

		if (this.Count == 0)
		{
			this.Last = First = newElement;
		}
		else
		{
			var first = this.First;
			first.Prev = newElement;
			newElement.Next = first;
			this.First = newElement;
		}

		this.Count++;
	}

	public void AddLast(T element)
	{
		var newElement = new Node<T>(element);
		if (this.Count == 0)
		{
			First = Last = newElement;
		}
		else
		{
			var last = this.Last;
			last.Next = newElement;
			newElement.Prev = last;
			this.Last = newElement;
		}
		this.Count++;
	}

	public T RemoveFirst()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}
		var element = this.First;
		var second = element.Next;
		this.First = second;
		this.Count--;
		return element.Value;
	}

	public T RemoveLast()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}

		var toRemove = this.Last;
		var secondToLast = toRemove.Prev;
		this.Last = secondToLast;
		this.Count--;
		return toRemove.Value;
	}

	public void ForEach(Action<T> action)
	{
		var current = this.First;
		for (int i = 0; i < this.Count; i++)
		{
			action(current.Value);
			current = current.Next;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		var current = this.First;
		for (int i = 0; i < this.Count; i++)
		{
			yield return current.Value;
			current = current.Next;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	public T[] ToArray()
	{
		var arr = new T[this.Count];
		var current = this.First;
		for (int i = 0; i < this.Count; i++)
		{
			arr[i] = current.Value;
			current = current.Next;
		}
		return arr;
	}
}

public class Node<T>
{

	public Node(T value)
	{
		this.Value = value;
	}
	public T Value { get; set; }
	public Node<T> Next { get; set; }
	public Node<T> Prev { get; set; }
}

class Example
{
	static void Main()
	{
		var list = new DoublyLinkedList<int>();

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");

		list.AddLast(5);
		list.AddFirst(3);
		list.AddFirst(2);
		list.AddLast(10);
		Console.WriteLine("Count = {0}", list.Count);

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");

		list.RemoveFirst();
		list.RemoveLast();
		list.RemoveFirst();

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");

		list.RemoveLast();

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");
	}
}
