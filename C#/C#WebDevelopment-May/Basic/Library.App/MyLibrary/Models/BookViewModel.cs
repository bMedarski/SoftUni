using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
	public class BookViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public string Author { get; set; }

		public int AuthorId { get; set; }

		public bool Available { get; set; }

	}
}
