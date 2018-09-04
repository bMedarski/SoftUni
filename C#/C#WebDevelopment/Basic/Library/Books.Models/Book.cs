using System.Collections.Generic;
using System.Net;

namespace Books.Models
{
	public class Book
	{
		public Book()
		{
			this.Borrowers = new List<BooksBorrowers>();
		}

		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string BookCoverImage { get; set; }

		public int AuthorId { get; set; }
		public Author Author { get; set; }

		public int StatusId { get; set; }
		public Status Status { get; set; }

		public ICollection<BooksBorrowers> Borrowers { get; set; }
	}
}
