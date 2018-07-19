using System.ComponentModel.DataAnnotations;
using CHUSKA.Models;

namespace CHUSHKA.App.ViewModels
{
    public class UserViewModel
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

	}
}
