using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
	private int count;
	public Node<T> Last { get; set; }
	public Node<T> First { get; set; }
	public int Count {
		get { return this.count; }
		private set { this.count = value; }
	}

    public void AddFirst(T item)
    {
        var newItem = new Node<T>(item);
	    newItem.Next = First;
	    First = newItem;
	    if (this.Count==0)
	    {
		    Last = newItem;
	    }
	    this.Count++;
    }
	
    public void AddLast(T item)
    {
		var old = this.Last;
		Last = new Node<T>(item);

		if (this.Count == 0)
		{
			First = Last;
		}
		else if(this.Count==1)
		{
			old.Next = Last;
			First.Next = Last;
		}
		else
		{
			old.Next = Last;
		}
		this.Count++;
	}

    public T RemoveFirst()
    {
	    if (this.Count==0)
	    {
		    throw new InvalidOperationException();
	    }
	    var first = this.First.Value;
	    var newFirst = this.First.Next;
	    this.First = newFirst;
	    this.Count--;
	    if (this.Count == 0)
	    {
		    this.Last = null;
	    }
	    return first;
    }

    public T RemoveLast()
    {
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}

	    var last = Last;
	    var current = First;
	    for (int i = 1; i < this.Count-1; i++)
	    {
		    current = current.Next;
	    }
	    current.Next = null;
	    this.Last = current;
	    this.Count--;

	    return last.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
	    var current = this.First;
	    while (current!=null)
	    {
		    yield return current.Value;
		    current = current.Next;
	    }
	    //yield return current.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
	    return this.GetEnumerator();
    }
}
