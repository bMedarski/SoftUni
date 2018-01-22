using System;
using System.Data;
using System.Linq;

public class ArrayStack<T>
{
	private T[] elements;
	public int Count { get; private set; }
	private const int InitialCapacity = 16;

	public ArrayStack(int capacity = InitialCapacity)
	{
		this.elements = new T[capacity];
	}

	public void Push(T element)
	{

		if (this.Count==this.elements.Length)
		{
			this.Grow();
		}
		this.elements[this.Count] = element;
		this.Count++;
	}

	public T Pop()
	{
		if (this.Count == 0)
		{
			throw  new InvalidOperationException();
		}
		var element = this.elements[this.Count - 1];
		this.Count--;
		return element;
	}

	public T[] ToArray()
	{
		var array = new T[this.Count];
		Array.Copy(this.elements.Reverse().Skip(this.elements.Length - this.Count).ToArray(), array, this.Count);
		return array;
	}

	private void Grow()
	{
		var newArr = new T[this.elements.Length * 2];
		Array.Copy(this.elements,newArr,this.Count);
		this.elements = newArr;
	}

	public void Print()
	{
		Console.WriteLine(string.Join(" ",this.elements));
	}
}
