using System.Collections.Generic;
using System.Linq;
using Books.App.Models;
using Books.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Pages
{
    public class IndexModel : PageModel
    {
	    public IndexModel(BooksContext context)
	    {
		    this.Context = context;
	    }

	    public BooksContext Context { get; set; }

	    public List<BookViewModel> Books { get; set; }
		[BindProperty]
	    public string Term { get; set; }
        public void OnGet()
        {
	        this.Books = this.Context.Books.Include(b => b.Author).Include(b=>b.Status).OrderBy(b => b.Title).Select(b =>
		        new BookViewModel()
		        {
			        Id = b.Id,
			        Title = b.Title,
			        Author = b.Author.Name,
			        AuthorId = b.AuthorId,
					Available = b.IsAvailable
		        }).ToList();
        }
	}
}
