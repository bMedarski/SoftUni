using Library.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibrary.Pages
{
    public class MainPageModel : PageModel
    {
		public MainPageModel(BooksContext context)
        {
	        this.Context = context;
        }

	    protected BooksContext Context { get; private set; }
	}
}