using System;

namespace Books.Models
{
    public class BooksBorrowers
    {
	    public int BookId { get; set; }

	    public Book Book { get; set; }

	    public int BorrowerId { get; set; }

	    public Borrower Borrower { get; set; }

	}
}
