using System.ComponentModel.DataAnnotations;
using System.Linq;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Pages.Books
{
    public class AddModel : MainPageModel
    {
	    public AddModel(BooksContext context) : base(context)
	    {
	    }

	    
		[BindProperty]
		[Required(ErrorMessage = "Title is required")]
		[MinLength(4, ErrorMessage = "Title must be min 4 letters long")]
		[MaxLength(20, ErrorMessage = "Title must be max 20 letters long")]
		public string Title { get; set; }

	    [BindProperty]
	    [DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Description is required")]
	    [MinLength(20, ErrorMessage = "Description must be min 20 letters long")]
		[MaxLength(750, ErrorMessage = "Description must be max 750 letters long")]
		public string Description { get; set; }

	    [BindProperty]
	    [Required(ErrorMessage = "Author is required")]
		[MinLength(4,ErrorMessage = "Author must be min 4 letters long")]
	    [MaxLength(20, ErrorMessage = "Author must be max 20 letters long")]
		public string Author { get; set; }

		[BindProperty]
		[Url]
		[MinLength(10,ErrorMessage = "Image URL must be min 10 symbols long")]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; }
		
        public void OnGet()
        {

        }

		public IActionResult OnPost()
		{
			if (!this.ModelState.IsValid)
			{
				return this.Page();
			}

			Library.Models.Author author = this.Context.Authors.Where(a => a.Name == this.Author).FirstOrDefault();
			if (author == null)
			{
				author = new Library.Models.Author()
				{
					Name = this.Author

				};
				this.Context.Authors.Add(author);
				this.Context.SaveChanges();
			}

			Book book = new Book()
			{
				Title = this.Title,
				Description = this.Description,
				BookCoverImage = this.ImageUrl,
				AuthorId = author.Id,
				IsAvailable = true
			};
			this.Context.Books.Add(book);
			this.Context.SaveChanges();

			return this.RedirectToPage("/Books/Details", new { id = book.Id });
		}
	}
}