using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
	private const int DefaultListSize = 4;
	private T[] list;
	private int size;

	public DoublyLinkedList()
	{
		this.size = DefaultListSize;
		this.list = new T[this.size];
	}

	public int Count { get; private set; }

	public void AddFirst(T element)
    {
	    if (this.size == this.Count)
	    {
		    this.ExpandList();
	    }

	    T prev = this.list[0];
	    for (int i = 1; i < this.Count; i++)
	    {
		    T current = this.list[i];
		    this.list[i] = prev;
		    prev = current;
	    }
		this.AddLast(prev);
	    this.list[0] = element;
    }

    public void AddLast(T element)
    {
	    if (this.size <= this.Count)
	    {
		    this.ExpandList();
	    }

	    this.list[this.Count] = element;
	    this.Count++;
    }

    public T RemoveFirst()
    {
	    throw new NotImplementedException();

    }

    public T RemoveLast()
    {
	    T element = this.list[this.Count - 1];
	    this.Count--;
	    return element;
    }

    public void ForEach(Action<T> action)
    {
	    for (int i = 0; i < this.Count; i++)
	    {
		    action(this.list[i]);
	    }
    }

    public IEnumerator<T> GetEnumerator()
    {
	    foreach (var item in this.list)
	    {
		    yield return item;
	    }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
	    return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

	private void ExpandList()
	{
		this.size *=  2;
		T[] newList =  new T[this.size];
		for (int i = 0; i < this.list.Length; i++)
		{
			newList[i] = this.list[i];
		}

		this.list = newList;
	}
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

        //list.RemoveFirst();
        //list.RemoveLast();
        //list.RemoveFirst();

        //list.ForEach(Console.WriteLine);
        //Console.WriteLine("--------------------");

        //list.RemoveLast();

        //list.ForEach(Console.WriteLine);
        //Console.WriteLine("--------------------");
    }
}
