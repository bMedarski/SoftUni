using System;
using System.Linq;
using System.Text;
using BookShop.Models;

namespace BookShop
{
	using BookShop.Data;
	using BookShop.Initializer;

	public class StartUp
	{
		public static void Main()
		{
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";

			System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;



			using (var db = new BookShopContext())
			{
				//DbInitializer.ResetDatabase(db);

				//var input = Console.ReadLine();
				//var year = int.Parse(Console.ReadLine());
				//var result = GetBooksByAgeRestriction(db, input);
				//var result = GetGoldenBooks(db);
				//var result = GetBooksByPrice(db);
				//var result = GetBooksNotRealeasedIn(db, year);
				//var result = GetBooksByCategory(db, input);
				//var result = GetBooksReleasedBefore(db, input);
				//var result = GetAuthorNamesEndingIn(db,input);
				//var result = GetBookTitlesContaining(db, input);
				//var result = GetBooksByAuthor(db, input);
				//var result = CountBooks(db, year);
				//var result = CountCopiesByAuthor(db);
				//var result = GetTotalProfitByCategory(db);
				//var result = GetMostRecentBooks(db);
				//IncreasePrices(db);
				var result = RemoveBooks(db);
				//Console.WriteLine($"There are {result} books with longer title than {year} symbols");
				Console.WriteLine($"{result} books were deleted");
				//Console.WriteLine(result);
			}
		}

		public static int RemoveBooks(BookShopContext context)
		{
			var books = context.Books.Where(b => b.Copies < 4200).ToList();
			var result = books.Count;
			context.RemoveRange(books);
			context.SaveChanges();
			return result;
		}
		public static void IncreasePrices(BookShopContext context)
		{
			var books = context.Books.Where(b => b.ReleaseDate.Value.Year <= 2009).ToList();

			foreach (var book in books)
			{
				book.Price += 5;
			}
			context.SaveChanges();
		}
		public static string GetMostRecentBooks(BookShopContext context)
		{
			var categories = context.Categories
				.OrderBy(c => c.Name)
				.Select(c => new
				{
					name = c.Name,
					books = c.CategoryBooks
						.OrderByDescending(cb => cb.Book.ReleaseDate)
						.Select(cb=>new
						{
							cb.Book.Title,
							cb.Book.ReleaseDate
						})
						.Take(3)
						.ToList()
				})				
				.ToList();

			var result = new StringBuilder();

			foreach (var category in categories)
			{
				result.AppendLine($"--{category.name}");
				foreach (var book in category.books)
				{
					result.Append(book.Title);
					result.Append(" (");
					result.Append(book.ReleaseDate.Value.Year);
					result.AppendLine(")");
					//($"{book.Book.Title} ({book.Book.ReleaseDate.Value.Year})");
				}
			}
			return result.ToString().Trim();
		}
		public static string GetTotalProfitByCategory(BookShopContext context)
		{
			var categories = context.Categories
				.Select(c => new
				{
					Name = c.Name,
					BooksProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
				})
				.OrderByDescending(c => c.BooksProfit)
				.ThenBy(c => c.Name)
				.ToList();

			var builder = new StringBuilder();

			foreach (var category in categories.OrderByDescending(c => c.BooksProfit))
			{

				var info = $"{category.Name} ${category.BooksProfit:f2}";
				builder.AppendLine(info);
			}

			return builder.ToString().TrimEnd();
		}
		public static string CountCopiesByAuthor(BookShopContext context)
		{
			var booksCount = context.Authors
				.OrderByDescending(a=>context.Books.Where(b => b.Author == a).Select(b => b.Copies).Sum())
				.Select(a => $"{a.FirstName} {a.LastName} - {context.Books.Where(b => b.Author == a).Select(b=>b.Copies).Sum()}")
				.ToList();

			var result = string.Join(Environment.NewLine, booksCount);
			return result;
		}
		public static int CountBooks(BookShopContext context, int lengthCheck)
		{
			var count = context.Books.Where(b => b.Title.Length > lengthCheck)
				.Count();

			var result = $"There are {count} books with longer title than {lengthCheck} symbols";
			return count;
		}
		public static string GetBooksByAuthor(BookShopContext context, string input)
		{
			var books = context.Books
				.OrderBy(b=>b.BookId)
				.Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
				.Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
				.ToList();
				

			var result = string.Join(Environment.NewLine, books);
			return result;
		}
		public static string GetBookTitlesContaining(BookShopContext context, string input)
		{
			var books = context.Books
				.Where(b=>b.Title.ToLower().Contains(input.ToLower()))
				.Select(b=>b.Title)
				.OrderBy(b=>b)
				.ToList();

			var result = string.Join(Environment.NewLine, books);
			return result;
		}
		public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
		{
			var authors = context.Authors
				.Where(a => a.FirstName.EndsWith(input))
				.Select(a => $"{a.FirstName} {a.LastName}")
				.OrderBy(a => a)
				.ToList();

			var result = string.Join(Environment.NewLine, authors);
			return result;
		}
		public static string GetBooksReleasedBefore(BookShopContext context, string date)
		{
			DateTime checkDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

			var books = context.Books
				.Where(b => b.ReleaseDate < checkDate)
				.OrderByDescending(b => b.ReleaseDate)
				.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
				.ToList();
			var result = string.Join(Environment.NewLine, books);
			return result;
		}
		public static string GetBooksByCategory(BookShopContext context, string input)
		{
			var categories = input.ToLower().Split(new[] { "\t", Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

			var books = context.Books
				.Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
				.Select(b => b.Title)
				.OrderBy(b=>b)
				.ToArray();

			var result = string.Join(Environment.NewLine, books);
			return result;
		}
		public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
		{
			var books = context.Books
				.Where(b => b.ReleaseDate.Value.Year != year)
				.OrderBy(b => b.BookId)
				.Select(b => b.Title)
				.ToArray();

			var result = string.Join(Environment.NewLine, books);
			return result;
		}
		public static string GetBooksByPrice(BookShopContext context)
		{
			var titles = context.Books
				.OrderByDescending(b => b.Price)
				.Where(b => b.Price > 40)
				.Select(b => $"{b.Title} - ${b.Price:F2}")
				.ToList();

			var result = string.Join(Environment.NewLine, titles);
			return result;
		}
		public static string GetGoldenBooks(BookShopContext context)
		{


			var titles = context.Books
				.OrderBy(b => b.BookId)
				.Where(b => (b.EditionType == EditionType.Gold) && (b.Copies < 5000))
				//.OrderBy(b=>b.BookId)
				.Select(b => b.Title)
				.ToList();
			var result = string.Join(Environment.NewLine, titles);

			return result;
		}
		public static string GetBooksByAgeRestriction(BookShopContext context, string command)
		{
			var books = context.Books
			 .OrderBy(b => b.Title)
			 .Where(b => b.AgeRestriction.ToString().Equals(command, StringComparison.InvariantCultureIgnoreCase))
			 .Select(b => b.Title)
			 .ToList();
			var result = string.Join(Environment.NewLine, books);

			return result;
		}
	}
}
