using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
	    this.Value = value;
	    this.Childrens = children;
    }

	public T Value { get; private set; }
	public IList<Tree<T>> Childrens { get; set; }

    public void Print(int indent = 0)
    {		
        Console.Write(new String(' ', indent));
		Console.WriteLine(this.Value);
	    foreach (var children in this.Childrens)
	    {
		    children.Print(indent+2);
	    }
    }

    public void Each(Action<T> action)
    {
	    action(this.Value);
	    foreach (var children in this.Childrens)
	    {
		    children.Each(action);
	    }
    }

    public IEnumerable<T> OrderDFS()
    {
		var list = new List<T>();
		this.Dfs(this,list);

		return list;
    }

	public void Dfs(Tree<T> node, IList<T> list)
	{
		foreach (var children in this.Childrens)
		{
			children.Dfs(children,list);
		}

		list.Add(this.Value);
	}

    public IEnumerable<T> OrderBFS()
    {
	    var list = new List<T>();
		list.Add(this.Value);
	    this.Bfs(this,list);

	    return list;
    }

	public void Bfs(Tree<T> node, IList<T> list)
	{
		foreach (var children in this.Childrens)
		{
			list.Add(children.Value);
		}
		foreach (var children in this.Childrens)
		{
			children.Bfs(children,list);
		}
	}
}
