using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()//6.Birthday
	{

		//List<IBirthdate> Identities = new List<IBirthdate>();
		//while (true)
		//{
		//	var input = Console.ReadLine().Split(' ').ToArray();
		//	if (input[0] == "End")
		//	{
		//		break;
		//	}
		//	if (input[0] == "Citizen")
		//	{
		//		var entity = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
		//		Identities.Add(entity);
		//	}
		//	else if (input[0] == "Pet")
		//	{
		//		var entity = new Pet(input[1], input[2]);
		//		Identities.Add(entity);
		//	}
		//}

		//var year = Console.ReadLine();
		//var pattern = $@"{year}\b";
		//Regex rgx = new Regex(pattern);
		//Identities.Where(x => rgx.IsMatch(x.Birthdate)).Select(x => x.Birthdate).ToList().ForEach(x=>Console.WriteLine(x));
		
		List<IBuyer> buyers = new List<IBuyer>();

		var buyersCount = int.Parse(Console.ReadLine());

		for (int i = 0; i < buyersCount; i++)
		{
			var input = Console.ReadLine().Split(' ').ToArray();
			if (input.Length == 4)
			{
				//“<name> <age> <id> <birthdate>
				var buyer = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
				buyers.Add(buyer);

			}else if (input.Length == 3)
			{
				var buyer = new Rebel(input[0], int.Parse(input[1]), input[2]);
				buyers.Add(buyer);
			}
		}

		while (true)
		{
			var input = Console.ReadLine();
			if (input=="End")
			{
				break;
			}
			if (buyers.Any(x=>x.Name==input))
			{
				buyers.First(x=>x.Name==input).BuyFood();
			}
		}
		var totalFood = 0;
		foreach (var buyer in buyers)
		{
			totalFood += buyer.Food;
		}
		Console.WriteLine(totalFood);
	}
}

