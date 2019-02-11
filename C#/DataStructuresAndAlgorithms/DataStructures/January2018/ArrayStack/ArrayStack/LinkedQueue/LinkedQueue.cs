using System;

public class LinkedQueue<T>
{
	public int Count { get; private set; }
	public QueueNode<T> First { get; set; }
	public QueueNode<T> Last { get; set; }

	public void Enqueue(T element)
	{
		var newElement = new QueueNode<T>(element);
		if (this.Count == 0)
		{
			this.First = this.Last = newElement;
		}
		else
		{
			var last = this.Last;
			this.Last = newElement;
			newElement.PrevNode = last;
			last.NextNode = newElement;
		}

		this.Count++;
	}

	public T Dequeue()
	{
		if (this.Count == 0)
		{
			throw  new InvalidOperationException();
		}
		var first = this.First;
		this.First = first.NextNode;

		this.Count--;
		return first.Value;
	}

	public T[] ToArray()
	{
		var arr = new T[this.Count];
		var current = this.First;

		for (int i = 0; i < this.Count; i++)
		{
			arr[i] = current.Value;
			current = current.NextNode;
		}

		return arr;
	}

	public  class QueueNode<T>
	{
		public QueueNode(T value)
		{
			this.Value = value;
		}
		public T Value { get; private set; }
		public QueueNode<T> NextNode { get; set; }
		public QueueNode<T> PrevNode { get; set; }
	}
}
