using System;

class Launcher
{
    public static void Main()
    {
	    LinkedList<int> list = new LinkedList<int>();

	    list.AddLast(1);

	    foreach (int item in list)
	    {
		    Console.WriteLine(item);
	    }
	}
}
