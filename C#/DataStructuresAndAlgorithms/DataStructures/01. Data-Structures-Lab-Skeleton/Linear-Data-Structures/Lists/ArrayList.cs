using System;

public class ArrayList<T>
{
	private int INITIAL_CAPACITY = 2;
	private int count = 0;
	private T[] list;

	public ArrayList()
	{
		this.list = new T[this.INITIAL_CAPACITY];
	}

	public int Count
	{
		get { return this.count; }
		private set { this.count = value; }
	}

	public T this[int index]
	{

		get
		{
			if (index >= this.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return this.list[index];
		}

		set
		{
			if (index >= this.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.list[index] = value;
		}
	}

	public void Add(T item)
	{
		if (this.count == this.list.Length)
		{
			this.Expand();
		}
		this.list[this.Count] = item;
		this.count++;
	}

	public T RemoveAt(int index)
	{


		if (index >= this.Count)
		{
			throw new ArgumentOutOfRangeException();
		}
		var item = this.list[index];

		for (int i = index; i < this.Count; i++)
		{
			this.list[i] = this.list[i + 1];
		}
		this.Count--;
		return item;
	}

	private void Expand()
	{
		var temp = new T[this.list.Length * 2];
		for (int i = 0; i < this.list.Length; i++)
		{
			temp[i] = this.list[i];
		}
		this.list = temp;
	}
}
