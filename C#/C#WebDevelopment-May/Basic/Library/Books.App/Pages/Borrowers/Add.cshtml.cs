using System.ComponentModel.DataAnnotations;
using Books.Data;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.App.Pages.Borrowers
{
    public class AddModel : PageModel
    {

	    public AddModel(BooksContext context)
	    {
		    this.Context = context;
	    }
	    public BooksContext Context { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[MinLength(5,ErrorMessage = "Min lenght of the name: 5")]
		[BindProperty]
		public string Name { get; set; }

		[Required(ErrorMessage = "Address is required")]
		[MinLength(5, ErrorMessage = "Min lenght of the address: 5")]
		[BindProperty]
		public string Address { get; set; }
        public IActionResult OnPost()
        {
			if (!this.ModelState.IsValid)
			{
				return this.RedirectToPage("/Error");
			}

	        var modelState = this.ModelState;
	        var borrower = new Borrower()
	        {
		        Name = this.Name,
		        Address = this.Address
	        };

	        this.Context.Borrowers.Add(borrower);
	        this.Context.SaveChanges();
	        return this.RedirectToPage("/Index");
        }
    }
}