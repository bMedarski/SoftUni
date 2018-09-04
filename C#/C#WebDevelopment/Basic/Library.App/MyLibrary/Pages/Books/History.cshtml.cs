using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Pages.Books
{
	public class HistoryModel : MainPageModel
	{
		public HistoryModel(BooksContext context)
			: base(context)
		{

		}

		public List<BookHistoryViewModel> BookHistory { get; set; }
		public void OnGet(int id)
		{
			this.BookHistory = Context.BooksBorrowerses
				.Include(b => b.Borrower)
				.Include(b => b.Book)
				.Where(b=>b.BookId == id)
				.Select(b => new BookHistoryViewModel()
				{
					Title = b.Book.Title,
					BorrowerName = b.Borrower.Name,
					ReturnDate = b.ReturnDate,
					LendDate = b.BorrowDate
				})
				.OrderBy(b=>b.LendDate)
				.ToList();
		}
	}
}