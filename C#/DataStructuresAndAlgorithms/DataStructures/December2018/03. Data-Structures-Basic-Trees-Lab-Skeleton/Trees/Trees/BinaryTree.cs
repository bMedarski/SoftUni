using System;

public class BinaryTree<T>
{
	public T Value { get; set; }
	public BinaryTree<T> Left { get; set; }
	public BinaryTree<T> Right { get; set; }


	public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
	{
		this.Value = value;
		this.Left = leftChild;
		this.Right = rightChild;
	}

	public void PrintIndentedPreOrder(int indent = 0)
	{
		Console.Write(new String(' ', indent));
		Console.WriteLine(this.Value);
		this.Left?.PrintIndentedPreOrder(indent + 2);

		this.Right?.PrintIndentedPreOrder(indent + 2);

	}

	public void EachInOrder(Action<T> action)
	{
		this.Left?.EachInOrder(action);
		action(this.Value);
		this.Right?.EachInOrder(action);
	}

	public void EachPostOrder(Action<T> action)
	{
		this.Left?.EachPostOrder(action);
		this.Right?.EachPostOrder(action);
		action(this.Value);
	}
}
