using System.Linq;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Pages.Books
{
    public class DetailsModel : MainPageModel
    {
		public DetailsModel(BooksContext context)
		    : base(context)
	    {

	    }

	    public string Title { get; set; }
	    public string Author { get; set; }
	    public string Description { get; set; }
	    public string ImageUrl { get; set; }
	    public bool IsAvailable { get; set; }
	    public int AuthorId { get; set; }
	    public int Id { get; set; }


	    public IActionResult OnGet(int id)
	    {
		    var book = Context.Books.
			    Include(b => b.Author)
			    .FirstOrDefault(b => b.Id == id);
		    if (book == null)
		    {
			    return this.NotFound();
		    }
		    this.Title = book.Title;
		    this.Author = book.Author.Name;
		    this.Description = book.Description;
		    this.ImageUrl = book.BookCoverImage;
		    this.IsAvailable = book.IsAvailable;
		    this.Id = book.Id;
		    this.AuthorId = book.AuthorId;

		    return this.Page();
	    }
	}
}