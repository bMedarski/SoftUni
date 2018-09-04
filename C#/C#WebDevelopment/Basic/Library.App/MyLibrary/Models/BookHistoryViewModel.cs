using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class BookHistoryViewModel
    {

	    public string Title { get; set; }

	    public string BorrowerName { get; set; }

	    public DateTime LendDate { get; set; }

	    public DateTime? ReturnDate { get; set; }
    }
}
