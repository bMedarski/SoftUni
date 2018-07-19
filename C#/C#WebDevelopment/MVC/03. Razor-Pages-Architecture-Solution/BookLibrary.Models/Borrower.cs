using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class Borrower
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BorrowersBooks> BorrowedBooks { get; set; }
    }
}
