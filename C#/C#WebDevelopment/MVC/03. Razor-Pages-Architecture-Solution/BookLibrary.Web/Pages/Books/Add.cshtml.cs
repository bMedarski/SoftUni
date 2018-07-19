using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.Web.Pages.Books
{
    public class AddModel : PageModel
    {
        public AddModel(BookLibraryContext context)
        {
            this.Context = context;
        }

        public BookLibraryContext Context { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var newBook = this.AddBook();
            return this.RedirectToPage("/Books/Details", new { id = newBook.Id });
        }

        private Book AddBook()
        {
            var author = this.CreateOrUpdateAuthor();

            var book = new Book()
            {
                Title = this.Title,
                Description = this.Description,
                CoverImage = this.ImageUrl,
                AuthorId = author.Id
            };

            this.Context.Books.Add(book);
            this.Context.SaveChanges();
            return book;
        }

        private Author CreateOrUpdateAuthor()
        {
            var author = this.Context.Authors
                .FirstOrDefault(a => a.Name == this.Author);
            if (author == null)
            {
                author = new Author()
                {
                    Name = this.Author
                };

                this.Context.Authors.Add(author);
                this.Context.SaveChanges();
            }

            return author;
        }
    }
}