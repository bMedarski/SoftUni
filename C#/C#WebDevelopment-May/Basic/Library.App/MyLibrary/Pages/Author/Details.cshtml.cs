using System.Collections.Generic;
using System.Linq;
using Books.App.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Pages.Author
{
    public class DetailsModel : MainPageModel
    {
	    public DetailsModel(BooksContext context)
			:base(context)
	    {
		    this.BookTitles = new List<AuthorViewModel>();
	    }

	    public IEnumerable<AuthorViewModel> BookTitles { get; set; }
	    public string Author { get; set; }
	    public int AuthorId { get; set; }
	    public void OnGet(int id)
	    {
		    var author = Context.Authors.Find(id);

		    this.BookTitles = Context.Books
			    .Include(b => b.Author)
			    .Where(b => b.AuthorId == id)
			    .Select(b => new AuthorViewModel()
			    {
				    Title = b.Title,
				    Id = b.Id
			    });
		    this.Author = author.Name;
		    this.AuthorId = author.Id;
	    }
	}
}