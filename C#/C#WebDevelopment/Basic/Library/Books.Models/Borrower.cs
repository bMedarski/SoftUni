using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Models
{
    public class Borrower
    {
	    public Borrower()
	    {
			this.Books = new List<BooksBorrowers>();
	    }

	    public int Id { get; set; }
	    public string Name { get; set; }

	    public string Address { get; set; }

	    public ICollection<BooksBorrowers> Books { get; set; }
    }
}
