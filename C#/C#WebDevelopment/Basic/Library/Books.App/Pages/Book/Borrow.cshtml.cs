using System;
using System.Collections.Generic;
using System.Linq;
using Books.Data;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Pages.Book
{
    public class BorrowModel : PageModel
    {
	    public BorrowModel(BooksContext context)
	    {
		    this.Context = context;
		    this.Borrowers = new List<Borrower>();
	    }
		public BooksContext Context { get; set; }
		public string Title { get; set; }
		public List<Borrower> Borrowers { get; set; }
		[BindProperty]
	    public int BorrowerId { get; set; }
	    [BindProperty]
		public int BookId { get; set; }
		[BindProperty]
		public DateTime ReturnDate { get; set; }
	    [BindProperty]
		public DateTime? LendDate { get; set; }
		public void OnGet(int id)
		{
			this.BookId = id;
			var book = this.Context.Books.Find(id);
			this.Title = book.Title;
			this.Borrowers = this.Context.Borrowers.ToList();
		}

	    public IActionResult OnPost(int bookId)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.Page();
		    }
			this.LendDate = DateTime.UtcNow;
		    if (this.LendDate > this.ReturnDate)
		    {
			    return this.Page();
			}


		    var book = this.Context.Books.Include(b=>b.Status).FirstOrDefault(b=>b.Id == bookId);

		    book.Status.IsAvailable = false;
		    book.Status.ReturnDate = this.ReturnDate;
		    book.Status.BorrowDate = DateTime.UtcNow;


		    var borrower = this.Context.Borrowers.Find(this.BorrowerId);
		    var bookBorrower = new BooksBorrowers()
		    {
			    BookId = book.Id,
			    Book = book,
			    BorrowerId = this.BorrowerId,
			    Borrower = borrower
		    };
		    borrower.Books.Add(bookBorrower);

		    this.Context.SaveChanges();

			return this.RedirectToPage("/Index");
	    }
    }
}