public class Node<T>
{
	private T value;
	public Node<T> NextNode { get; set; }

	public T Value { get { return this.value; } private set { this.value = value; } }

	public Node(T value, Node<T> nextNode = null)
	{
		this.value = value;
		this.NextNode = nextNode;
	}
}
