using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Data;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Pages.Book
{
    public class ReturnModel : PageModel
    {

	    public ReturnModel(BooksContext context)
	    {
		    this.Context = context;
	    }

	    public BooksContext Context { get; set; }
        public IActionResult OnGet(int id)
        {

	        var book = Context.Books.
		        Include(b => b.Author)
		        .Include(b => b.Status)
		        .FirstOrDefault(b => b.Id == id);
	        if (book == null)
	        {
		        return this.NotFound();
	        }

	        book.Status.IsAvailable = true;
	        this.Context.SaveChanges();

	        return this.RedirectToPage("/Index");
        }
    }
}