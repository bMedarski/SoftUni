using BookLibrary.Data;
using BookLibrary.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(BookLibraryContext context)
        {
            this.Context = context;
        }

        public BookLibraryContext Context { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }

        public void OnGet()
        {
            this.Books = this.Context.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .Select(BookConciseViewModel.FromBook)
                .ToList();
        }
    }
}
