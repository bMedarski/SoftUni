using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Pages.Book
{
    public class DetailsModel : PageModel
    {

	    public DetailsModel(BooksContext context)
	    {
		    this.Context = context;
	    }

	    public BooksContext Context{ get; set; }

		[BindProperty]
	    public string Title { get; set; }
	    [BindProperty]
	    public string Author { get; set; }
	    [BindProperty]
	    public string Description { get; set; }
	    [BindProperty]
	    public string ImageUrl { get; set; }

	    public bool IsAvailable { get; set; }
	    public int AuthorId { get; set; }
	    public int Id { get; set; }


		public IActionResult OnGet(int id)
        {
	        var book = Context.Books.
		        Include(b=>b.Author)
		        .Include(b=>b.Status)
		        .FirstOrDefault(b=>b.Id==id);
	        if (book == null)
	        {
		        return this.NotFound();
	        }
	        this.Title = book.Title;
	        this.Author = book.Author.Name;
	        this.Description = book.Description;
	        this.ImageUrl = book.BookCoverImage;
	        this.IsAvailable = book.Status.IsAvailable;
	        this.Id = book.Id;
	        this.AuthorId = book.AuthorId;

	        return this.Page();
        }
    }
}