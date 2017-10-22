using System;

class Program
{
	static void Main()
	{
		var list = new AddRemoveCollection();

		list.Add("PEsho");
		list.Add("tt");
		list.Add("bb");

		Console.WriteLine(list.Remove());
	}
}

