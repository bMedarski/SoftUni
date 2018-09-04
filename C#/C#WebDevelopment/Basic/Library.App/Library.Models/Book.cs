using System.Collections.Generic;

namespace Library.Models
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

	    public bool IsAvailable { get; set; }

	    public ICollection<BooksBorrowers> Borrowers { get; set; }
	}
}
