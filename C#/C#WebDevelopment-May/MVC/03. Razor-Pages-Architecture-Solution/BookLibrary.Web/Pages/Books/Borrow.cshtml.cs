using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.Web.Pages.Books
{
    public class BorrowModel : PageModel
    {
        public BorrowModel(BookLibraryContext context)
        {
            this.Context = context;
            this.Borrowers = new List<SelectListItem>();
            this.StartDate = DateTime.Now;
        }

        public BookLibraryContext Context { get; private set; }

        [BindProperty]
        [Required(ErrorMessage = "You have to specify a borrower.")]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }

        public void OnGet()
        {
            this.Borrowers = this.Context.Borrowers
                .Select(b => new SelectListItem()
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToList();
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                // TODO: Show error messages
                return;
            }

            // TODO: If the book has been borrowed for the current period, return an error message
            var borrower = this.Context.Borrowers.Find(this.BorrowerId);
            int bookId = Convert.ToInt32(this.RouteData.Values["id"]);
            var book = this.Context.Books.Find(bookId);
            if (borrower == null || book == null)
            {
                // TODO: ModelState.AddModelError()
                return;
            }

            var borrowedBook = new BorrowersBooks()
            {
                BookId = book.Id,
                BorrowerId = borrower.Id,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };

            this.Context.BorrowedBooks.Add(borrowedBook);
            this.Context.SaveChanges();
        }
    }
}