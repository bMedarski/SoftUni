using System.ComponentModel.DataAnnotations;
using Library.Data;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Pages.Borrower
{
    public class AddModel : MainPageModel
    {
	    public AddModel(BooksContext context)
			:base(context)
	    {
		    
	    }
		[Required(ErrorMessage = "Name is required")]
	    [MinLength(5, ErrorMessage = "Name min lenght must be 5")]
	    [BindProperty]
	    public string Name { get; set; }

	    [Required(ErrorMessage = "Address is required")]
	    [MinLength(5, ErrorMessage = "Address min length must be 5")]
	    [BindProperty]
	    public string Address { get; set; }
	    public IActionResult OnPost()
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.Page();
		    }

		    var borrower = new Library.Models.Borrower()
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