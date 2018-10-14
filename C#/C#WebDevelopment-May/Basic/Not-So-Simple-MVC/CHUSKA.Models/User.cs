using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CHUSKA.Models
{
    public class User
    {
		[Key]
		[Required]
	    public int Id { get; set; }

	    [Required]
		public string Username { get; set; }

	    [Required]
		public string Password { get; set; }

	    public string FullName { get; set; }

		[Required]
	    public string Email { get; set; }

	    [Required]
		public Role Role { get; set; }

	    public ICollection<Order> Orders { get; set; }

    }
}
