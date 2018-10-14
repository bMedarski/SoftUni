using BookLibrary.Models;
using System;

namespace BookLibrary.Web.Models
{
    public class BookConciseViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public static Func<Book, BookConciseViewModel> FromBook
        {
            get
            {
                return book => new BookConciseViewModel()
                {
                    BookId = book.Id,
                    Title = book.Title,
                    Author = book.Author.Name,
                    AuthorId = book.Author.Id
                };
            }
        }
    }
}
