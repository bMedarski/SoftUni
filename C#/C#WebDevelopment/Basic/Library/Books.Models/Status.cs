using System;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Status
    {
	    public int Id { get; set; }

		public bool IsAvailable { get; set; }

	    public DateTime BorrowDate { get; set; }

	    public DateTime? ReturnDate { get; set; }
	}
}
