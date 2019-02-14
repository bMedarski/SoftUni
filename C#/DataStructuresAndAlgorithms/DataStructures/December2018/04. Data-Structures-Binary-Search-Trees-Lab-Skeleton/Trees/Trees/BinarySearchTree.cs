using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
	public Node Root { get; set; }

    public void Insert(T value)
    {
		if (this.Root == null)
		{
			this.Root = new Node
			{
				Value = value
			};
		}
		else
		{
			this.Insert(this.Root,value);
	    }
		
    }

	public Node Insert(Node current, T value)
	{
		if (current == null)
		{
			current = new Node
			{
				Value = value
			};
			return current;
		}
		else if (current.Value.CompareTo(value) > 0)
		{
			current.Left = this.Insert(current.Left,value);
		}
		else if (current.Value.CompareTo(value) < 0)
		{
			current.Right = this.Insert(current.Right,value);
		}

		return current;
	}

    public bool Contains(T value)
    {
	    return this.GetValue(this.Root, value);

    }

	private bool GetValue(Node parent ,T value)
	{
		if (parent == null)
		{
			return false;
		}
		else if(parent.Value.CompareTo(value)>0)
		{
			return this.GetValue(parent.Left, value);
		}
		else if(parent.Value.CompareTo(value)<0)
		{
			return this.GetValue(parent.Right, value);
		}
		else if(parent.Value.CompareTo(value)==0)
		{
			return true;
		}

		return false;
	}

    public void DeleteMin()
    {
	    var min = this.GetMin(this.Root);
	    if (min.Right == null)
	    {
			
	    }
    }

	private Node GetMin(Node parent)
	{
		if (parent.Left == null)
		{
			return parent;
		}
		else
		{
			return this.GetMin(parent.Left);
		}
	}

	//private Node GetParent(Node child)
	//{
	//	if (this.Contains(child.Value))
	//	{
	//		if(this.Root)
	//	}
	//}
    public BinarySearchTree<T> Search(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
		this.Each(this.Root,action);
    }

	private void Each(Node node, Action<T> action)
	{
		if (node.Left != null)
		{
			action(node.Left.Value);
		}
		action(node.Value);
		if (node.Right != null)
		{
			action(node.Right.Value);
		}
	}

	public class Node
	{
		public T Value { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
	}
}

public class Launcher
{
    public static void Main(string[] args)
    {
	    BinarySearchTree<int> bst = new BinarySearchTree<int>();
	    bst.Insert(1);

	    // Act
	    List<int> nodes = new List<int>();
	    bst.EachInOrder(nodes.Add);

	    // Assert
	    int[] expectedNodes = new int[] { 1 };
    }
}
