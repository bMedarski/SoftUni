
using System.Collections.Generic;

namespace Books.Models
{
    public class Author
    {
	    public Author()
	    {
		    this.Books = new List<Book>();
	    }
	    public int Id { get; set; }

	    public string Name { get; set; }

	    public IEnumerable<Book> Books { get; set; }

    }
}
