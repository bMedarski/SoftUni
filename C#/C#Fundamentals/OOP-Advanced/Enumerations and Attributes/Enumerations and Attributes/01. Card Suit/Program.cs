using System;
using System.ComponentModel;

class Program
{
	static void Main(string[] args)
	{
		//var input = Console.ReadLine();

		//if (input == "Rank")
		//{
		//	var type = typeof(CardTypes);
		//	var attrs = type.GetCustomAttributes(false);

		//	foreach (TypeAttribute attr in attrs)
		//	{
		//		Console.WriteLine(attr);
		//	}
		//}
		//else
		//{
		//	var type = typeof(Cards);
		//	var attrs = type.GetCustomAttributes(false);

		//	foreach (TypeAttribute attr in attrs)
		//	{
		//		Console.WriteLine(attr);
		//	}
		//}
		//var suit = Console.ReadLine();
		//var cardOne = new Card(suit, type);


		//var type2 = Console.ReadLine();
		//var suit2 = Console.ReadLine();
		//var cardTwo = new Card(suit2, type2);

		//if (cardOne.CompareTo(cardTwo) == 1)
		//{
		//	Console.WriteLine(cardOne);
		//}
		//else if (cardOne.CompareTo(cardTwo) == -1)
		//{
		//	Console.WriteLine(cardTwo);
		//}
		//else
		//{
		//	Console.WriteLine(cardTwo);
		//}
		foreach (var suit in Enum.GetValues(typeof(Cards)))
		{
			foreach (var type in Enum.GetValues(typeof(CardTypes)))
			{
				Console.WriteLine(type+" of "+suit);
			}
		}
	}
}

