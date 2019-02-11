//using System;
//using System.Data;
//using System.Linq;

//public class ArrayStack<T>
//{
//	private T[] elements;
//	public int Count { get; private set; }
//	private const int InitialCapacity = 16;

//	public ArrayStack(int capacity = InitialCapacity)
//	{
//		this.elements = new T[capacity];
//	}

//	public void Push(T element)
//	{

//		if (this.Count==this.elements.Length)
//		{
//			this.Grow();
//		}
//		this.elements[this.Count] = element;
//		this.Count++;
//	}

//	public T Pop()
//	{
//		if (this.Count == 0)
//		{
//			throw  new InvalidOperationException();
//		}
//		var element = this.elements[this.Count - 1];
//		this.Count--;
//		return element;
//	}

//	public T[] ToArray()
//	{
//		var array = new T[this.Count];
//		Array.Copy(this.elements.Reverse().Skip(this.elements.Length - this.Count).ToArray(), array, this.Count);
//		return array;
//	}

//	private void Grow()
//	{
//		var newArr = new T[this.elements.Length * 2];
//		Array.Copy(this.elements,newArr,this.Count);
//		this.elements = newArr;
//	}

//	public void Print()
//	{
//		Console.WriteLine(string.Join(" ",this.elements));
//	}
//}
using System;

public class ArrayStack<T>
{
	private T[] elements;

	public int Count { get; private set; }

	private const int InitialCapacity = 2;

	public ArrayStack(int capacity = InitialCapacity)
	{
		this.elements = new T[capacity];
	}
	public void Push(T element)
	{

		if (this.Count == this.elements.Length)
		{
			this.Grow();
		}
		this.elements[this.Count] = element;
		this.Count++;
	}

	public T Pop()
	{
		int index = this.Count - 1;
		CheckArrLenght(index);

		T deletedElement = this.elements[index];
		this.elements[index] = default(T);
		this.Count--;

		if (this.Count <= this.elements.Length / 4)
		{
			this.Shrink();
		}
		return deletedElement;
	}

	public T[] ToArray()
	{
		var resultArr = new T[this.Count];
		CopyAllElementsTo(resultArr);
		return resultArr;
	}

	private void Grow()
	{
		var newElements = new T[2 * this.elements.Length];
		Array.Copy(this.elements, newElements, this.Count);
		this.elements = newElements;
	}

	private void CopyAllElementsTo(T[] resultArr)
	{
		for (int i = 0; i < this.Count; i++)
		{
			resultArr[i] = this.elements[i];
		}
	}

	private void CopyAllElementsTo(T[] newElements, T element)
	{
		newElements[0] = element;
		Count++;

		for (int i = 1; i < this.Count; i++)
		{
			newElements[i] = this.elements[i - 1];
		}
	}

	private void CheckArrLenght(int index)
	{
		if (index < 0 || index >= this.Count)
		{
			throw new ArgumentOutOfRangeException();
		}
	}

	private void Shrink()
	{
		T[] newArr = new T[this.elements.Length / 2];
		Array.Copy(this.elements, newArr, this.Count);
		this.elements = newArr;
	}
	public void Print()
	{
		Console.WriteLine(string.Join(" ", this.elements));
	}
}
