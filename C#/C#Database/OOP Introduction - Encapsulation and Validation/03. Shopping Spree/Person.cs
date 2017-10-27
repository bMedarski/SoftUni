using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
	private string name;

	private decimal money;

	private ICollection<Product> ShopingBag { get; set; }

	public string Name
	{
		get { return this.name; }
		set
		{
			if (value != string.Empty)
			{
				this.name = value;
			}
			else
			{
				throw new Exception("Name cannot be empty");
			}
		}
	}

	public decimal Money
	{
		get { return this.money; }
		set
		{
			if (value >= 0)
			{
				this.money = value;
			}
			else
			{
				throw new Exception("Money cannot be negative");
			}
		}
	}

	public Person(string name, decimal money) : base()
	{
		this.Name = name;
		this.Money = money;
		this.ShopingBag = new List<Product>();
	}

	public void Buy(Product product)
	{
		if (this.Money >= product.Money)
		{
			this.Money -= product.Money;
			this.ShopingBag.Add(product);
		}
		else
		{
			throw new Exception($"{this.Name} can't afford {product.ProductName}");
		}
	}

	public override string ToString()
	{
		if (this.ShopingBag.Count > 0)
		{
			var purchases = this.ShopingBag.Select(p => p.ProductName).ToArray();
			return $"{this.Name} - {string.Join(", ", purchases)}";
		}
		else
		{
			return $"{this.Name} - Nothing bought";
		}
	}
}