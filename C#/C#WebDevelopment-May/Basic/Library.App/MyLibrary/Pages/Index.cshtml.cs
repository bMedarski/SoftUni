using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Pages
{
	public class IndexModel : MainPageModel
	{
		public IndexModel(BooksContext context)
			:base(context)
		{
			
		}
		public List<BookViewModel> Books { get; set; }

		public void OnGet()
		{
			var con = this.Context;
			Console.WriteLine();
			this.Books = this.Context.Books.Include(b => b.Author).OrderBy(b => b.Title).Select(b =>
				new BookViewModel()
				{
					Id = b.Id,
					Title = b.Title,
					Author = b.Author.Name,
					AuthorId = b.AuthorId,
					Available = b.IsAvailable
				}).ToList();
		}
	}
}
