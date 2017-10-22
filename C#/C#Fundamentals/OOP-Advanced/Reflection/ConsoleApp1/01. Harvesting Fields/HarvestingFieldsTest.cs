using System.Linq;
using System.Reflection;
using System.Text;

namespace _01HarestingFields
{
	using System;

	class HarvestingFieldsTest
	{
		static void Main()
		{
			Type classType = Type.GetType("HarvestingFields", false);
			var sb = new StringBuilder();


			while (true)
			{
				var input = Console.ReadLine();
				if (input == "HARVEST")
				{
					break;
				}
				if (input == "public")
				{
					//var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
					//foreach (var methodInfo in fields.Where(m => m.IsPublic))
					//{
					//	sb.AppendLine($"{input} {methodInfo.FieldType} {methodInfo.Name}");
					//}
					Console.WriteLine($"{classType.BaseType}");
				}
			}
		}
	}
}
