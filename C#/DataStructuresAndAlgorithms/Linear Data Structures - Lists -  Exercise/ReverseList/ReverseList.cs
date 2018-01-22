
using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable
{
	private const int DefaultArrayCapacity = 16;

	private T[] array;

	public ReversedList()
	{
		this.array = new T[DefaultArrayCapacity];
	}

	public int Count { get; set; }

	public int Capacity => this.array.Length;

	public T this[int index]
	{
		get
		{
			if (index < 0 || index >= this.Count)
			{
				throw new InvalidOperationException("Index was out of boundries of the list.");
			}

			return this.array[this.Count - 1 - index];
		}

		set
		{
			if (index < 0 || index >= this.Count)
			{
				throw new InvalidOperationException("Index was out of boundries of the list.");
			}

			this.array[this.Count - 1 - index] = value;
		}
	}

	public void Add(T element)
	{
		if (this.Count == this.Capacity)
		{
			this.DoubleCapacity();
		}

		this.array[this.Count] = element;
		this.Count++;
	}

	public void Remove(int index)
	{
		if (index < 0 || index >= this.Count)
		{
			throw new InvalidOperationException("Index was out of boundries of the list.");
		}

		var indexToRemove = this.Count - 1 - index;

		var newArray = new T[this.Capacity];

		var oldArrayIndex = 0;
		var newArrayIndex = 0;
		while (oldArrayIndex < this.Count)
		{
			if (indexToRemove != oldArrayIndex)
			{
				newArray[newArrayIndex] = this.array[oldArrayIndex];
				newArrayIndex++;
			}

			oldArrayIndex++;
		}

		this.array = newArray;
		this.Count--;
	}

	public IEnumerator<T> GetEnumerator()
	{
		var currentIndex = 0;
		while (currentIndex < this.Count)
		{
			yield return this.array[this.Count - 1 - currentIndex];
			currentIndex++;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	private void DoubleCapacity()
	{
		var newArray = new T[this.Capacity * 2];
		for (int index = 0; index < this.Count; index++)
		{
			newArray[index] = this.array[index];
		}

		this.array = newArray;
	}
}
