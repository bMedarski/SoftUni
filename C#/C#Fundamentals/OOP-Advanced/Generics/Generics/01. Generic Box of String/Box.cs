using System;


public class Box<T>
	where T : IComparable
{
	private T value;

	public T Value
	{
		get { return this.value; }
		private set { this.value = value; }
	}

	public Box(T value)
	{
		this.Value = value;
	}
	public int CompareTo(T other)
	{
		return this.Value.CompareTo(other);
	}
	
	public override string ToString()
	{
		Type typeParameterType = typeof(T);
		return $"{typeParameterType}: {this.Value}";
	}
}

