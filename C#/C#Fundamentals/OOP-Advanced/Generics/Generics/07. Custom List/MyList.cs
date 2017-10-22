using System;
using System.Collections.Generic;
using System.Linq;

public class MyList<T>:IMyList<T>
	where T : IComparable
{

	private List<T> list;

	public MyList()
	{
		this.list = new List<T>();
	}

	public void Add(T element)
	{
		this.list.Add(element);
	}

	public T Remove(int index)
	{
		var item = this.list[index];
		this.list.RemoveAt(index);
		return item;
	}

	public bool Contains(T element)
	{
		//var index = this.list.IndexOf(element);
		//if (index < 0)
		//{
		//	return false;
		//}
		//else
		//{
		//	return true;
		//}
		return this.list.Contains(element);
	}

	public void Swap(int index1, int index2)
	{
		var temp = this.list[index1];
		this.list[index1] = this.list[index2];
		this.list[index2] = temp;
	}

	public int CountGreaterThan(T element)
	{
		//var count = 0;
		//foreach (var item in this.list)
		//{
		//	if (item.CompareTo(element) > 0)
		//	{
		//		count++;
		//	}
		//}
		//return count;
		return this.list.Count(item => item.CompareTo(element) > 0);
	}
	public T Max()
	{
		//var max = this.list[0];
		//foreach (var item in this.list)
		//{
		//	if (item.CompareTo(max)>0)
		//	{
		//		max = item;
		//	}
		//}

		//return max;
		return this.list.Max();
	}

	public T Min()
	{
		//var min = this.list[0];
		//foreach (var item in this.list)
		//{
		//	if (item.CompareTo(min) < 0)
		//	{
		//		min = item;
		//	}
		//}

		//return min;
		return this.list.Min();
	}

	public void Print()
	{
		foreach (var item in this.list)
		{
			Console.WriteLine(item);
		}
	}

}

