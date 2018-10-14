using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyLibrary.Pages.Books
{
	public class BorrowModel : MainPageModel
	{
		public BorrowModel(BooksContext context)
			: base(context)
		{
			this.Borrowers = new List<SelectListItem>();
			this.LendDate = DateTime.UtcNow;
		}

		public string Title { get; set; }
	    public List<SelectListItem> Borrowers { get; set; }
	    [BindProperty]
	    public int BorrowerId { get; set; }
	    public int BookId { get; set; }
	    [BindProperty]
	    public DateTime? ReturnDate { get; set; }
	    [BindProperty]
	    public DateTime LendDate { get; set; }
	    public void OnGet(int id)
	    {
		    this.BookId = id;
		    var book = this.Context.Books.Find(id);
		    this.Title = book.Title;
		    this.Borrowers = this.Context.Borrowers.Select(b=> new SelectListItem()
		    {
				Value = (b.Id).ToString(),
				Text = b.Name
		    }).ToList();
	    }

	    public IActionResult OnPost(int bookId)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.Page();
		    }
		    if (this.ReturnDate!=null && this.LendDate > this.ReturnDate)
		    {
			    return this.Page();
		    }


		    var book = this.Context.Books.FirstOrDefault(b => b.Id == bookId);

		    book.IsAvailable = false;


		    var borrower = this.Context.Borrowers.Find(this.BorrowerId);
		    var bookBorrower = new BooksBorrowers()
		    {
			    BookId = book.Id,
			    Book = book,
			    BorrowerId = this.BorrowerId,
			    Borrower = borrower,
				ReturnDate = this.ReturnDate,
				BorrowDate = this.LendDate
		    };
		    borrower.Books.Add(bookBorrower);
		    this.Context.SaveChanges();

		    return this.RedirectToPage("/Index");
	    }
	}
}