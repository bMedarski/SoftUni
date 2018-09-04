using System;
using System.Linq;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Pages.Books
{
    public class ReturnModel : MainPageModel
    {
	    public ReturnModel(BooksContext context)
			:base(context)
	    {
		    
	    }
		public IActionResult OnGet(int id)
		{

			var book = this.Context.Books
				.Include(b=>b.Borrowers)
				.ThenInclude(b=>b.Borrower)
				.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return this.NotFound();
			}

			book.IsAvailable = true;

			book.Borrowers.ToList().LastOrDefault().ReturnDate = DateTime.UtcNow;

			this.Context.SaveChanges();

			return this.RedirectToPage("/Index");
		}
	}
}