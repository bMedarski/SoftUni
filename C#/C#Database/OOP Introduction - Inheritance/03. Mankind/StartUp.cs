using System;
using System.Linq;

class StartUp
{
	static void Main()
	{

		var studentArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
		var workerArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
		try
		{
			var student = new Student(studentArgs[0], studentArgs[1], studentArgs[2]);
			var worker = new Worker(workerArgs[0], workerArgs[1], double.Parse(workerArgs[2]), double.Parse(workerArgs[3]));
			Console.WriteLine(student);
			Console.WriteLine(worker);

		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}




	}
}

