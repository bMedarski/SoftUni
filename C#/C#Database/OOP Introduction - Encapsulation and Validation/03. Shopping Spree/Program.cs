using System;
using System.Collections.Generic;

public class StartUp
{
	static List<Person> persons = new List<Person>();
	static List<Product> products = new List<Product>();

	public static void Main(string[] args)
	{
		try
		{
			AddPersons();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}

		try
		{
			AddProducts();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}

		var input = Console.ReadLine();

		while (input != "END")
		{
			var splited = Split(input, ' ');
			ShopingTime(splited[0], splited[1]);

			input = Console.ReadLine();
		}

		PrintPersonsWithTheirPurchases();
	}

	private static void AddProducts()
	{
		foreach (var item in Split(Console.ReadLine(), ';'))
		{
			if (item != string.Empty)
			{
				var splitedItem = Split(item, '=');
				products.Add(new Product(splitedItem[0], Convert.ToDecimal(splitedItem[1])));
			}
		}
	}
	private static void AddPersons()
	{
		foreach (var item in Split(Console.ReadLine(), ';'))
		{
			if (item != string.Empty)
			{
				var splitedItem = Split(item, '=');
				persons.Add(new Person(splitedItem[0], Convert.ToDecimal(splitedItem[1])));
			}
		}
	}
	static string[] Split(string input, char ch)
	{
		return input.Split(ch);
	}
	static void ShopingTime(string personName, string productName)
	{
		var currentPerson = persons.Find(pn => pn.Name == personName);
		var currentProduct = products.Find(pt => pt.ProductName == productName);
		try
		{
			currentPerson.Buy(currentProduct);
			Console.WriteLine($"{personName} bought {productName}");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	static void PrintPersonsWithTheirPurchases()
	{
		foreach (var person in persons)
		{
			Console.WriteLine(person.ToString());
		}
	}
}