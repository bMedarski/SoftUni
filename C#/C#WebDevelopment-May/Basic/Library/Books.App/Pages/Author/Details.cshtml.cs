using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.App.Models;
using Books.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Books.App.Pages.Author
{
	public class DetailsModel : PageModel
	{
		public DetailsModel(BooksContext context)
		{
			this.Context = context;
			this.BookTitles = new List<AuthorViewModel>();
		}

		public BooksContext Context { get; set; }

		public IEnumerable<AuthorViewModel> BookTitles { get; set; }
		public string Author { get; set; }
		public int AuthorId { get; set; }
		public void OnGet(int id)
		{
			var author = Context.Authors.Find(id);

			this.BookTitles = Context.Books
				.Include(b => b.Author)
				.Where(b => b.AuthorId == id)
				.Select(b => new AuthorViewModel()
				{
					Title = b.Title,
					Id = b.Id
				});
			this.Author = author.Name;
			this.AuthorId = author.Id;
		}
	}
}