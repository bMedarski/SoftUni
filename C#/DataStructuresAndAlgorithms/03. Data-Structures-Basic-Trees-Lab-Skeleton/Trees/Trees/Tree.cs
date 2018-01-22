using System;
using System.Collections.Generic;

public class Tree<T>
{
	public IList<Tree<T>> Children { get; private set; }
	public T Value { get; private set; }

	public Tree(T value, params Tree<T>[] children)
	{
		this.Value = value;
		this.Children = new List<Tree<T>>();
		foreach (var child in children)
		{
			this.Children.Add(child);
		}
	}


	public void Print(int indent = 0)
	{
		Console.WriteLine($"{new String(' ', 2 * indent)}{this.Value}");
		foreach (var child in this.Children)
		{
			child.Print(indent + 1);
		}
	}

	public void Each(Action<T> action)
	{
		action(this.Value);
		foreach (var child in this.Children)
		{
			child.Each(action);
		}
	}

	public IEnumerable<T> OrderDFS()
	{
		var result = new List<T>();
		this.DFS(this, result);
		return result;
	}

	public void DFS(Tree<T> node, IList<T> list)
	{

		foreach (var child in node.Children)
		{
			this.DFS(child, list);
		}
		list.Add(node.Value);
	}

	public IEnumerable<T> OrderBFS()
	{
		List<T> list = new List<T>();
		var queue = new Queue<Tree<T>>();
		queue.Enqueue(this);

		while (queue.Count > 0)
		{
			var current = queue.Dequeue();
			foreach (var currentChild in current.Children)
			{
				queue.Enqueue(currentChild);
			}
			list.Add(current.Value);
		}
		return list;
	}
}
