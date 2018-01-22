using System;
using System.Xml;

public class BinaryTree<T>
{
	public T Value { get; private set; }
	public BinaryTree<T> LeftChild { get; private set; }
	public BinaryTree<T> RightChild { get; private set; }

	public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
	{
		this.Value = value;
		this.LeftChild = leftChild;
		this.RightChild = rightChild;
	}

	public void PrintIndentedPreOrder(int indent = 0)
	{
		if (this != null)
		{
			Console.WriteLine($"{new string(' ',indent)}{this.Value}");

		}
		if (this.LeftChild != null)
		{
			this.LeftChild.PrintIndentedPreOrder(indent + 2);
		}
		if (this.RightChild != null)
		{
			this.RightChild.PrintIndentedPreOrder(indent + 2);
		}
	}

	public void EachInOrder(Action<T> action)
	{
		if (this.LeftChild != null)
		{
			this.LeftChild.EachInOrder(action);
		}
		if (this != null)
		{
			action(this.Value);

		}
		if (this.RightChild != null)
		{
			this.RightChild.EachInOrder(action);
		}
	}

	public void EachPostOrder(Action<T> action)
	{
		if (this.LeftChild != null)
		{
			this.LeftChild.EachPostOrder(action);
		}
		if (this.RightChild != null)
		{
			this.RightChild.EachPostOrder(action);
		}
		if (this != null)
		{
			action(this.Value);

		}
	}
}
