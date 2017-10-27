using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

class StartUp
{
	static void Main()
	{
		Type boxType = typeof(Box);
		FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
		Console.WriteLine(fields.Count());

		var lenght = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
		var width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
		var height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
		Box box;
		try
		{
			box = new Box(lenght,height,width);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			return;
		}
		

		Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
		Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
		Console.WriteLine($"Volume - {box.Volume():F2}");
	}
}

