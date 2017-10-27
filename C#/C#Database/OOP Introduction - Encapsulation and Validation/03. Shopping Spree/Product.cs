using System;

public class Product
{
	private string productName;

	private decimal price;

	public string ProductName
	{
		get { return this.productName; }
		set
		{
			if (value != string.Empty)
			{
				this.productName = value;
			}
			else
			{
				throw new Exception("Name cannot be empty");
			}
		}
	}

	public decimal Money
	{
		get { return this.price; }
		set
		{
			if (value > 0)
			{
				this.price = value;
			}
			else
			{
				throw new Exception("Price cannot be zero or negative");
			}
		}
	}

	public Product(string productName, decimal price) : base()
	{
		this.ProductName = productName;
		this.Money = price;
	}
}