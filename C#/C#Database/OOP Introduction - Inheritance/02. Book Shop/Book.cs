using System;
using System.Linq;
using System.Text;

public class Book
{
	private string author;
	private string title;
	private decimal price;

	public Book(string author, string title, decimal price)
	{
		this.Title = title;
		this.Author = author;
		this.Price = price;
	}

	public string Author
	{
		get { return this.author; }
		set
		{
			var names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (names.Length > 1)
			{
				var lastName = names[names.Length - 1];
				if (char.IsDigit(lastName[0]))
				{
					throw new ArgumentException("Author not valid!");
				}
			}
			this.author = value;
		}
	}

	public string Title
	{
		get
		{
			return this.title;
		}

		protected set
		{
			if (value.Length <= 3)
			{
				throw new ArgumentException("Title not valid!");
			}
			this.title = value;
		}
	}

	public virtual decimal Price
	{
		get
		{
			return this.price;
		}
		protected set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Price not valid!");
			}
			this.price = value;
		}
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append("Type: ").AppendLine(this.GetType().Name)
			.Append("Title: ").AppendLine(this.Title)
			.Append("Author: ").AppendLine(this.Author)
			.Append("Price: ").Append($"{this.Price:f2}")
			.AppendLine();

		return sb.ToString();
	}

}