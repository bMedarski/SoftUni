using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;
	public T[] list;
	private int start = 0;
	private int end = 0;
	private int count = 0;
	private int capacity = DefaultCapacity;

    public int Count { get { return this.count; } private set { this.count = value; } }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.list = new T[capacity];
    }

    public void Enqueue(T element)
    {
	    if (this.Count==this.list.Length)
	    {
		    this.Resize();
	    }
	    //if (this.end==this.Count)
	    //{
		   // this.end = 0;
	    //}
	    this.list[end] = element;
	    this.end = (this.end + 1) % this.capacity;
	    this.Count++;
    }

    private void Resize()
    {
	    var newList = new T[this.list.Length * 2];
		this.CopyAllElements(newList);
	    this.start = 0;
	    this.end = this.count;
	    this.capacity *= 2;
    }

    private void CopyAllElements(T[] newArray)
    {
		Array.Copy(this.list,newArray,this.count);
	    //for (int i = 0; i < this.count; i++)
	    //{
		   // newArray[0] = this.list[(this.start + i) % this.count];
	    //}
	    this.list = newArray;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
	    if (this.count==0)
	    {
		    throw new InvalidOperationException();
	    }
	    T element = this.list[this.start];

		this.start=(this.start+1)%this.capacity;
	    this.count--;
	    return element;
    }

    public T[] ToArray()
    {
	    var array = new T[this.Count];
		Array.Copy(this.list,array,this.Count);
	    return array;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
		queue.Enqueue(4);
		queue.Enqueue(5);
		queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        //queue.Enqueue(-7);
        //queue.Enqueue(-8);
        //queue.Enqueue(-9);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //queue.Enqueue(-10);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");
    }
}
