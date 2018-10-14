namespace SimpleMvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Tubes = new HashSet<Tube>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Username should be at least 3 symbols long")]
        [MaxLength(30, ErrorMessage = "Username should be at most 30 symbols long")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Tube> Tubes { get; set; }
    }
}
