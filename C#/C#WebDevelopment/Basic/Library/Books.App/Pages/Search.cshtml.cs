using System.Collections.Generic;
using System.Linq;
using Books.App.Models;
using Books.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.App.Pages
{
    public class SearchModel : PageModel
	{
		public SearchModel(BooksContext context)
		{
			this.Context = context;
			this.SearchResults = new List<SearchViewModel>();
		}


		public BooksContext Context { get; set; }

		public List<SearchViewModel> SearchResults { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }
        public void OnGet()
        {

			if (string.IsNullOrEmpty(this.SearchTerm))
			{
				return;
			}

	        var authors = Context.Authors.Where(a => a.Name.ToLower().Contains(this.SearchTerm.ToLower())).Select(a => new SearchViewModel()
	        {
		        Id = a.Id,
		        Name = a.Name,
		        Type = "author"
	        }).ToList();

			var books = Context.Books.Where(b => b.Title.ToLower().Contains(this.SearchTerm.ToLower())).Select(b => new SearchViewModel()
			{
				Id = b.Id,
				Name = b.Title,
				Type = "book"
			}).ToList();

	        this.SearchResults.AddRange(authors);
	        this.SearchResults.AddRange(books);
	        this.SearchResults = SearchResults.OrderBy(r => r.Name).ToList();
        }
    }
}