using System.ComponentModel.DataAnnotations;
using System.Linq;
using Books.Data;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.App.Pages.Book
{
    public class AddModel : PageModel
    {
	    public AddModel(BooksContext context)
	    {
		    this.Context = context;
	    }

	    public BooksContext Context { get; set; }

		[BindProperty]
		[Required(ErrorMessage = "Author is required")]
		[MinLength(4,ErrorMessage = "Author must be at least 4 letters long")]
		[MaxLength(20, ErrorMessage = "Author must be at most 20 letters long")]
		public string Author { get; set; }

		[BindProperty]
		[DataType(DataType.MultilineText)]
		[MinLength(20, ErrorMessage = "Description must be at least 20 letters long")]
		[MaxLength(100, ErrorMessage = "Description must be at most 100 letters long")]
		public string Description { get; set; }
		[BindProperty]
		[Required(ErrorMessage = "Title is required")]
		[MinLength(4, ErrorMessage = "Title must be at least 4 letters long")]
		[MaxLength(20, ErrorMessage = "Title must be at most 20 letters long")]
		public string Title { get; set; }
		[BindProperty]
		[Url]
		[Display(Name= "Image URL")]
		[MinLength(8, ErrorMessage = "Image URL must be at least 8 letters long")]
		public string ImageUrl { get; set; }

	    public bool IsAvailable { get; set; }


	    public IActionResult OnPost()
	    {
		    if (!this.ModelState.IsValid)
		    {
				return this.Page();
		    }

		    Books.Models.Author author = this.Context.Authors.Where(a => a.Name == this.Author).FirstOrDefault();
		    if (author == null)
		    {
			    author = new Books.Models.Author()
			    {
				    Name = this.Author
					
			    };
			    this.Context.Authors.Add(author);
			    this.Context.SaveChanges();
		    }

		    var status = new Status()
		    {
			    IsAvailable = true
		    };
			Books.Models.Book book = new Books.Models.Book()
			{
				Title = this.Title,
				Description = this.Description,
				BookCoverImage = this.ImageUrl,
				AuthorId = author.Id,
				Status = status
			};
		    this.Context.Books.Add(book);
		    this.Context.SaveChanges();

		    return this.RedirectToPage("/Book/Details",new {id = book.Id});
	    }
	}
}